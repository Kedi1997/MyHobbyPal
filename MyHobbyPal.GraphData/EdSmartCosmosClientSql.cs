﻿#region Using directives
using CosmosDB.Net;
using CosmosDB.Net.Domain;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
#endregion

namespace MyHobbyPal.GraphData
{
    /// <summary>
    /// Wrapper class around the Azure.Comsos.Container class to be used when connecting to a CosmosDB SQL database
    /// Exposes all upstream SDK objects: <see cref="CosmosClient"/>, <see cref="Database"/> for direct access to base functionality 
    /// Exposes wrapper methods for easy item management, support for Model attributes, fast bulk inserts
    /// </summary>
    #region EdSmart Cosmos client SQL
    public class EdSmartCosmosClientSql : ICosmosClientSql, IDisposable
    {
        private const string SqlAccountEndpointFormat = "https://{0}.documents.azure.com:443/";

        private string _partitionKeyPropertyName;

        public CosmosEntitySerializer CosmosSerializer { get; private set; }

        public CosmosClient Client { get; private set; }
        public Database Database { get; private set; }
        public Container Container { get; private set; }

        #region Initialization


        /// <summary>
        /// Initialize a CosmosClient by providing the accountName and key.
        /// If database or container do not exist under the account, the <paramref name="createOptions"/> must be provided and include required parameters to create the database and container.
        /// If database or container do not exist under the account, and a <paramref name="createOptions"/> is not provided, the method will throw an exception.
        /// If database and container exist under the account, <paramref name="createOptions"/> will be ignored if passed in.
        /// </summary>
        /// <param name="accountName">Name of the Cosmos account to connect to. (i.e [yourAccount] from -> https://yourAccount.documents.azure.com:443/)</param>
        /// <param name="key">Account Key from the Key blade in the portal</param>
        /// <param name="databaseId">Id of the Database to connect to.</param>
        /// <param name="containerId">Id of the Container to connect to.</param>
        /// <param name="createOptions">Speficies the options for creating a new database and contianer if need be (throughput, partitionKey, indexing strategy, TTL etc..)</param>
        /// <exception cref="Exception">If database or container do not exist under the account, and a <paramref name="createOptions"/> is not provided, the method will throw an exception.</exception>
        /// <returns>Reference to a Sql CosmosClient</returns>
        public static Task<ICosmosClientSql> GetByAccountName(string accountName, string key, string databaseId, string containerId, bool isCloud = true, CreateOptions createOptions = null)
        {
            var accountEndpoint = isCloud ? string.Format(EdSmartCosmosClientSql.SqlAccountEndpointFormat, accountName) : $"https://{accountName}:8081/";
            return GetByAccountEndpoint(accountEndpoint, key, databaseId, containerId, createOptions);
        }

        /// <summary>
        /// Initialize a CosmosClient by providing the accountName and key.
        /// If database or container do not exist under the account, the <paramref name="createOptions"/> must be provided and include required parameters to create the database and container.
        /// If database or container do not exist under the account, and a <paramref name="createOptions"/> is not provided, the method will throw an exception.
        /// If database and container exist under the account, <paramref name="createOptions"/> will be ignored if passed in.
        /// </summary>
        /// <param name="connectionString">Connection String to a CosmosDB. (i.e. AccountEndpoint=***;AccountKey=***;)</param>
        /// <param name="databaseId">Id of the Database to connect to.</param>
        /// <param name="containerId">Id of the Container to connect to.</param>
        /// <param name="createOptions">Speficies the options for creating a new database and contianer if need be (throughput, partitionKey, indexing strategy, TTL etc..)</param>
        /// <exception cref="Exception">If database or container do not exist under the account, and a <paramref name="createOptions"/> is not provided, the method will throw an exception.</exception>
        /// <returns>Reference to a Sql CosmosClient</returns>
        public static Task<ICosmosClientSql> GetByConnectionString(string connectionString, string databaseId, string containerId, CreateOptions createOptions = null)
        {
            return GetCosmosDbClientInternal(new CosmosClient(connectionString, createOptions?.ClientOptions ?? CreateOptions.DefaultClientOptions), databaseId, containerId, createOptions);
        }

        /// <summary>
        /// Initialize a CosmosClient by providing the accountName and key.
        /// If database or container do not exist under the account, the <paramref name="createOptions"/> must be provided and include required parameters to create the database and container.
        /// If database or container do not exist under the account, and a <paramref name="createOptions"/> is not provided, the method will throw an exception.
        /// If database and container exist under the account, <paramref name="createOptions"/> will be ignored if passed in.
        /// </summary>
        /// <param name="accountEndpoint">Endpoint of the Cosmos account to connect to. (i.e https://youraccount.documents.azure.com:443/) </param>
        /// <param name="key">Account Key from the Key blade in the portal</param>
        /// <param name="databaseId">Id of the Database to connect to.</param>
        /// <param name="containerId">Id of the Container to connect to.</param>
        /// <param name="createOptions">Speficies the options for creating a new database and contianer if need be (throughput, partitionKey, indexing strategy, TTL etc..)</param>
        /// <exception cref="Exception">If database or container do not exist under the account, and a <paramref name="createOptions"/> is not provided, the method will throw an exception.</exception>
        /// <returns>Reference to a Sql CosmosClient</returns>
        public static Task<ICosmosClientSql> GetByAccountEndpoint(string accountEndpoint, string key, string databaseId, string containerId, CreateOptions createOptions = null)
        {
            return GetCosmosDbClientInternal(new CosmosClient(accountEndpoint, key, createOptions?.ClientOptions ?? CreateOptions.DefaultClientOptions), databaseId, containerId, createOptions);
        }


        private static async Task<ICosmosClientSql> GetCosmosDbClientInternal(CosmosClient client, string databaseId, string containerId, CreateOptions createOptions = null)
        {
            Database database = null;
            Container container = null;

            if (createOptions != null)
            {
                database = await client.CreateDatabaseIfNotExistsAsync(databaseId, createOptions.DatabaseThrouhput);
                container = await database.CreateContainerIfNotExistsAsync(createOptions.Container, createOptions.ContainerThroughput);
            }
            else
            {
                database = client.GetDatabase(databaseId);
                var ensureDbExists = await database.ReadAsync();
                if (ensureDbExists.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new Exception($"Database '{databaseId}' not found. Use forceCreate:true if you want the database to be created for you.");

                container = database.GetContainer(containerId);
                var ensureExists = await container.ReadContainerAsync();
                if (ensureExists.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new Exception($"Container '{containerId}' not found. Use forceCreate:true if you want a collection to be created for you.");
            }


            var res = new EdSmartCosmosClientSql
            {
                Client = client,
                Database = database,
                Container = container
            };

            var r = await container.ReadContainerAsync();
            res._partitionKeyPropertyName = r.Resource.PartitionKeyPath.Trim('/');
            res.CosmosSerializer = new CosmosEntitySerializer(res._partitionKeyPropertyName);
            return res;
        }

        #endregion


        /// <summary>
        /// Insert a document into the database. 
        /// The 3 main properties needed to properly insert a document (id, partitionkey and label) are going to be inferred as follows:
        /// If the type is decorated with attributes (<see cref="CosmosDB.Net.Domain.Attributes.PartitionKeyAttribute"/>,  <see cref="CosmosDB.Net.Domain.Attributes.IdAttribute"/> or <see cref="CosmosDB.Net.Domain.Attributes.LabelAttribute"/>)
        /// then the values of those properties will be used.
        /// If attributes are not detected, the values from the properties specified as parameters of this method will be tried next.
        /// If property expressions are not provided, the values of default properties will be tried next (id or whatever the PartitionKey property is set on the target collection). A label property will not be attempted.
        /// If there are still no values at this point the following defaults will be used:
        ///  id -> new guid
        ///  label -> name fo type
        ///  partitionkey -> throw an exception.
        /// </summary>
        /// <param name="document">Entity to insert</param>
        /// <param name="pkProperty">Mandatory. Accessor func for the method to extraact partitionKey for your object.</param>
        /// <param name="idProperty">Mandatory. Accessor func for the method to extract id for your object. Mandatory if your type T does not contain a property called id.</param>
        /// <param name="labelProperty">Optional. Accessor func for the method to extract label for your object.</param>
        /// <remarks>The method will fail if a value cannot be found for partition key</remarks>
        /// <returns><see cref="CosmosResponse"/> that tracks success status along with various performance parameters</returns>
        public Task<CosmosResponse> InsertDocument<T>(T document, Expression<Func<T, object>> pkProperty = null, Expression<Func<T, object>> idProperty = null, Expression<Func<T, object>> labelProperty = null)
        {
            return InsertDocumentInternal(CosmosSerializer.ToCosmosDocument(document, pkProperty, idProperty, labelProperty));
        }

        /// <summary>
        /// Insert a document stream into the database.
        /// </summary>
        /// <param name="stream">Stream to insert</param>
        /// <param name="partitionKey">PartitionKey to send</param>
        /// <returns><see cref="CosmosResponse"/> that tracks success status along with various performance parameters</returns>
        public Task<CosmosResponse> InsertDocument(Stream stream, PartitionKey partitionKey)
        {
            return InsertDocumentStreamInternal(stream, partitionKey);
        }

        /// <summary>
        /// Insert multiple documents into the database using a TPL Dataflow block.
        /// </summary>
        /// <param name="documents">Documents to insert</param>
        /// <param name="reportingCallback">[Optional] Method to be called based on the <paramref name="reportingInterval"/>. Generally used to provide a progress update to callers. Defaults to null./></param>
        /// <param name="reportingInterval">[Optional] interval in seconds to to call the reporting callback. Defaults to 10s</param>
        /// <param name="threads">[Optional] Number of threads to use for the paralel execution. Defaults to 4</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation</param>
        /// <example>
        /// <![CDATA[
        /// await _client.InsertDocuments(elements, (partial) => { Console.WriteLine($"inserted {partial.Count()} documents");
        /// ]]>
        /// </example>
        /// <returns><see cref="CosmosResponse"/> that tracks success status along with various performance parameters.</returns>
        public Task<IEnumerable<CosmosResponse>> InsertDocuments<T>(IEnumerable<T> documents, Action<IEnumerable<CosmosResponse>> reportingCallback = null, TimeSpan? reportingInterval = null, int threads = 4, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ProcessMultipleDocuments(documents, (d) => InsertDocument(d), reportingCallback, reportingInterval, threads, cancellationToken);
        }

        /// <summary>
        /// Insert multiple documents into the database using a TPL Dataflow block.
        /// The documents that are passed in are going to be added to the database using the Stream APIs so they will not be seriazlied / deseriazlied in the SDK
        /// Each document passed in must contain a property that matches the partitionKey property assigned on the collection
        /// </summary>
        /// <param name="documents">Documents to insert</param>
        /// <param name="reportingCallback">[Optional] Method to be called based on the <paramref name="reportingInterval"/>. Generally used to provide a progress update to callers. Defaults to null./></param>
        /// <param name="reportingInterval">[Optional] interval in seconds to to call the reporting callback. Defaults to 10s</param>
        /// <param name="threads">[Optional] Number of threads to use for the paralel execution. Defaults to 4</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation</param>
        /// <example>
        /// <![CDATA[
        /// await _client.InsertDocuments(elements, (partial) => { Console.WriteLine($"inserted {partial.Count()} documents");
        /// ]]>
        /// </example>
        /// <returns><see cref="CosmosResponse"/> that tracks success status along with various performance parameters.</returns>
        public Task<IEnumerable<CosmosResponse>> InsertDocuments(IEnumerable<(Stream stream, PartitionKey pk)> documents, Action<IEnumerable<CosmosResponse>> reportingCallback = null, TimeSpan? reportingInterval = null, int threads = 4, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ProcessMultipleStreamDocuments(documents, InsertDocument, reportingCallback, reportingInterval, threads, cancellationToken);
        }


        /// <summary>
        /// Upsert (Insert or Create) a document into the database.
        /// The 3 main properties needed to properly insert a document (id, partitionkey and label) are going to be inferred as follows:
        /// If the type is decorated with attributes (<see cref="CosmosDB.Net.Domain.Attributes.PartitionKeyAttribute"/>,  <see cref="CosmosDB.Net.Domain.Attributes.IdAttribute"/> or <see cref="CosmosDB.Net.Domain.Attributes.LabelAttribute"/>)
        /// then the values of those properties will be used.
        /// If attributes are not detected, the values from the properties specified as parameters of this method will be tried next.
        /// If property expressions are not provided, the values of default properties will be tried next (id or whatever the PartitionKey property is set on the target collection). A label property will not be attempted.
        /// If there are still no values at this point the following defaults will be used:
        ///  id -> new guid
        ///  label -> name fo type
        ///  partitionkey -> throw an exception.
        /// </summary>
        /// <param name="document">Entity to upsert</param>
        /// <param name="pkProperty">Mandatory. Accessor func for the method to extraact partitionKey for your object.</param>
        /// <param name="idProperty">Mandatory. Accessor func for the method to extract id for your object. Mandatory if your type T does not contain a property called id.</param>
        /// <param name="labelProperty">Optional. Accessor func for the method to extract label for your object.</param>
        /// <remarks>The method will fail if a value cannot be found for partition key</remarks>
        /// <returns><see cref="CosmosResponse"/> that tracks success status along with various performance parameters</returns>
        public Task<CosmosResponse> UpsertDocument<T>(T document, Expression<Func<T, object>> pkProperty = null, Expression<Func<T, object>> idProperty = null, Expression<Func<T, object>> labelProperty = null)
        {
            return UpsertDocumentInternal(CosmosSerializer.ToCosmosDocument(document, pkProperty, idProperty, labelProperty));
        }

        /// <summary>
        /// Upsert (Insert or Create) a document stream into the database.
        /// </summary>
        /// <param name="stream">Stream to insert</param>
        /// <param name="partitionKey">PartitionKey to send</param>
        /// <returns><see cref="CosmosResponse"/> that tracks success status along with various performance parameters</returns>
        public Task<CosmosResponse> UpsertDocument(Stream stream, PartitionKey partitionKey)
        {
            return UpsertDocumentStreamInternal(stream, partitionKey);
        }

        /// <summary>
        /// Upsert (Insert or Update) multiple documents into the database using a TPL Dataflow block.
        /// </summary>
        /// <param name="documents">Documents to upsert</param>
        /// <param name="reportingCallback">[Optional] Method to be called based on the <paramref name="reportingInterval"/>. Generally used to provide a progress update to callers. Defaults to null./></param>
        /// <param name="reportingInterval">[Optional] interval in seconds to to call the reporting callback. Defaults to 10s</param>
        /// <param name="threads">[Optional] Number of threads to use for the paralel execution. Defaults to 4</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation</param>
        /// <example>
        /// <![CDATA[
        /// await _client.InsertDocuments(elements, (partial) => { Console.WriteLine($"upserted {partial.Count()} documents");
        /// ]]>
        /// </example>
        /// <returns><see cref="CosmosResponse"/> that tracks success status along with various performance parameters.</returns>
        public Task<IEnumerable<CosmosResponse>> UpsertDocuments<T>(IEnumerable<T> documents, Action<IEnumerable<CosmosResponse>> reportingCallback = null, TimeSpan? reportingInterval = null, int threads = 4, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ProcessMultipleDocuments(documents, (d) => UpsertDocument(d), reportingCallback, reportingInterval, threads, cancellationToken);
        }

        /// <summary>
        /// Upsert (Insert or Update) multiple document streams into the database using a TPL Dataflow block.
        /// The documents that are passed in are going to be added to the database using the Stream APIs so they will not be seriazlied / deseriazlied in the SDK
        /// each document passed in must contain a property that matches the partitionKey property assigned on the collection
        /// </summary>
        /// <param name="documents">Documents to upsert</param>
        /// <param name="reportingCallback">[Optional] Method to be called based on the <paramref name="reportingInterval"/>. Generally used to provide a progress update to callers. Defaults to null./></param>
        /// <param name="reportingInterval">[Optional] interval in seconds to to call the reporting callback. Defaults to 10s</param>
        /// <param name="threads">[Optional] Number of threads to use for the paralel execution. Defaults to 4</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation</param>
        /// <example>
        /// <![CDATA[
        /// await _client.InsertDocuments(elements, (partial) => { Console.WriteLine($"upserted {partial.Count()} documents");
        /// ]]>
        /// </example>
        /// <returns><see cref="CosmosResponse"/> that tracks success status along with various performance parameters.</returns>
        public Task<IEnumerable<CosmosResponse>> UpsertDocuments(IEnumerable<(Stream stream, PartitionKey pk)> documents, Action<IEnumerable<CosmosResponse>> reportingCallback = null, TimeSpan? reportingInterval = null, int threads = 4, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ProcessMultipleStreamDocuments(documents, UpsertDocument, reportingCallback, reportingInterval, threads, cancellationToken);
        }



        /// <summary>
        /// Read a document by its Id and Partition Key. 
        /// This is the fastest operation possible in a CosmosDB collection.
        /// </summary>
        public async Task<CosmosResponse<T>> ReadDocument<T>(string docId, string partitionKey)
        {
            try
            {
                var start = DateTime.Now;

                var res = await Container.ReadItemAsync<T>(docId, new PartitionKey(partitionKey));

                var cr = res.ToCosmosResponse<T, T>(DateTime.Now.Subtract(start));
                cr.Result = res.Resource;
                return cr;
            }
            catch (CosmosException cex)
            {
                return cex.ToCosmosResponse<T>();
            }
            catch (Exception e)
            {
                return new CosmosResponse<T> { Error = e, StatusCode = System.Net.HttpStatusCode.InternalServerError };
            }
        }

        /// <summary>
        /// Gets all documents of the given type from the collection.
        /// </summary>
        /// <param name="filter">Optional filter argument (i.e "budget &gt; 100000 and revenue &lt; 3000000".</param>
        /// <param name="label">Type of document to retrieve. If empty, attempt to get value from the Attribute name or class name.</param>
        /// <param name="cancellationToken">cancellatinToken used to cancel an operation in progress.</param>
        /// <returns>Collection of results.</returns>
        public Task<CosmosResponse<IEnumerable<T>>> ReadDocuments<T>(string filter = "", string label = "", CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!string.IsNullOrEmpty(filter)) filter = "and " + filter;
            if (string.IsNullOrEmpty(label)) label = CosmosEntitySerializer.GetLabelForType(typeof(T));

            var query = $"select * from c where c.label = '{label}' {filter}";

            return ExecuteSQL<T>(query, cancellationToken: cancellationToken);
        }


        /// <summary>
        /// Executes a SQL Query against the collection
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="pagedResults">true to return only one page of the result set, false(Default) to return all results. </param>
        /// <param name="continuationToken">token to pass into the query iterator to resume from a specific page. Should be present when using pageResults = true</param>
        /// <param name="cancellationToken">cancellatinToken used to cancel an operation in progress.</param>
        /// <returns>Collection of results.</returns>
        public async Task<CosmosResponse<IEnumerable<T>>> ExecuteSQL<T>(string query, bool pagedResults = false, string continuationToken = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            DateTime start = DateTime.Now;
            CosmosResponse<IEnumerable<T>> cosmosResult = new CosmosResponse<IEnumerable<T>>();
            var dataResult = new List<T>();
            try
            {
                var iterator = Container.GetItemQueryIterator<T>(query, continuationToken);
                while (iterator.HasMoreResults)
                {
                    var readNext = await iterator.ReadNextAsync(cancellationToken);

                    dataResult.AddRange(readNext.Resource);

                    cosmosResult.RequestCharge += readNext.RequestCharge;
                    cosmosResult.ContinuationToken = readNext.ContinuationToken;
                    cosmosResult.ActivityId = readNext.ActivityId;
                    cosmosResult.ETag = readNext.ETag;

                    if (pagedResults) //Just read the next page of the result set if we are paging results
                        break;
                }
                cosmosResult.Result = dataResult;
                cosmosResult.ExecutionTime = DateTime.Now.Subtract(start);
                cosmosResult.StatusCode = System.Net.HttpStatusCode.OK;
                return cosmosResult;
            }
            catch (CosmosException cex)
            {
                return cex.ToCosmosResponse<IEnumerable<T>>();
            }
            catch (Exception e)
            {
                return new CosmosResponse<IEnumerable<T>> { Error = e, StatusCode = System.Net.HttpStatusCode.InternalServerError };
            }
        }


        /// <summary>
        /// Dispose of cosmos client
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of cosmos client
        /// </summary>
        /// <param name="disposing">True if disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.Client != null)
            {
                this.Client.Dispose();
                this.Client = null;
            }
        }

        #region Helpers

        internal Task<CosmosResponse> InsertDocumentInternal(IDictionary<string, object> document)
        {
            if (!document.ContainsKey(_partitionKeyPropertyName))
                throw new InvalidOperationException($"Document does not have a partition key property. Expecting '{_partitionKeyPropertyName}'");
            return AddDocumentInternal(() => Container.CreateItemAsync(document, new PartitionKey(document[_partitionKeyPropertyName].ToString())));
        }

        internal Task<CosmosResponse> InsertDocumentStreamInternal(Stream stream, PartitionKey partitionKey)
        {
            return AddDocumentStreamInternal(() => Container.CreateItemStreamAsync(stream, partitionKey));
        }


        internal Task<CosmosResponse> UpsertDocumentInternal(IDictionary<string, object> document)
        {
            if (!document.ContainsKey(_partitionKeyPropertyName))
                throw new InvalidOperationException($"Document does not have a partition key property. Expecting '{_partitionKeyPropertyName}'");
            return AddDocumentInternal(() => Container.UpsertItemAsync(document, new PartitionKey(document[_partitionKeyPropertyName].ToString())));
        }

        internal Task<CosmosResponse> UpsertDocumentStreamInternal(Stream stream, PartitionKey partitionKey)
        {
            return AddDocumentStreamInternal(() => Container.UpsertItemStreamAsync(stream, partitionKey));
        }


        internal async Task<CosmosResponse> AddDocumentInternal(Func<Task<ItemResponse<IDictionary<string, object>>>> addFunc)
        {
            try
            {
                var start = DateTime.Now;

                var res = await addFunc.Invoke();

                return res.ToCosmosResponse(DateTime.Now.Subtract(start));
            }
            catch (CosmosException cex)
            {
                return cex.ToCosmosResponse();
            }
            catch (Exception e)
            {
                return new CosmosResponse { Error = e, StatusCode = System.Net.HttpStatusCode.InternalServerError };
            }
        }

        internal async Task<CosmosResponse> AddDocumentStreamInternal(Func<Task<ResponseMessage>> addFunc)
        {
            try
            {
                var start = DateTime.Now;

                var res = await addFunc.Invoke();

                return new CosmosResponse
                {
                    ExecutionTime = DateTime.Now.Subtract(start),
                    StatusCode = res.StatusCode,

                    RequestCharge = res.Headers.RequestCharge,

                    ActivityId = res.Headers.ActivityId,
                    ETag = res.Headers.ETag
                };
            }
            catch (CosmosException cex)
            {
                return cex.ToCosmosResponse();
            }
            catch (Exception e)
            {
                return new CosmosResponse { Error = e, StatusCode = System.Net.HttpStatusCode.InternalServerError };
            }
        }


        internal async Task<IEnumerable<CosmosResponse>> ProcessMultipleDocuments<T>(IEnumerable<T> documents, Func<T, Task<CosmosResponse>> execute, Action<IEnumerable<CosmosResponse>> reportingCallback, TimeSpan? reportingInterval = null, int threads = 4, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!reportingInterval.HasValue) reportingInterval = TimeSpan.FromSeconds(10);
            ConcurrentBag<CosmosResponse> cb = new ConcurrentBag<CosmosResponse>();
            Timer statsTimer = null;
            if (reportingCallback != null)
            {
                statsTimer = new Timer(_ =>
                {
                    reportingCallback?.Invoke(cb.ToArray());
                }, null, (int)reportingInterval.Value.TotalMilliseconds, (int)reportingInterval.Value.TotalMilliseconds);
            }

            var actionBlock = new ActionBlock<T>(async (i) =>
            {
                var res = await execute(i);
                cb.Add(res);
            }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = threads, CancellationToken = cancellationToken });

            foreach (var i in documents)
            {
                actionBlock.Post(i);
            }
            actionBlock.Complete();
            await actionBlock.Completion;

            statsTimer?.Dispose();
            reportingCallback?.Invoke(cb.ToArray());
            return cb.ToArray();
        }

        internal async Task<IEnumerable<CosmosResponse>> ProcessMultipleStreamDocuments(IEnumerable<(Stream stream, PartitionKey pk)> documents, Func<Stream, PartitionKey, Task<CosmosResponse>> execute, Action<IEnumerable<CosmosResponse>> reportingCallback, TimeSpan? reportingInterval = null, int threads = 4, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!reportingInterval.HasValue) reportingInterval = TimeSpan.FromSeconds(10);
            ConcurrentBag<CosmosResponse> cb = new ConcurrentBag<CosmosResponse>();
            Timer statsTimer = null;
            if (reportingCallback != null)
            {
                statsTimer = new Timer(_ =>
                {
                    reportingCallback?.Invoke(cb.ToArray());
                }, null, (int)reportingInterval.Value.TotalMilliseconds, (int)reportingInterval.Value.TotalMilliseconds);
            }

            var actionBlock = new ActionBlock<(Stream stream, PartitionKey pk)>(async (t) =>
            {
                var res = await execute(t.stream, t.pk);
                cb.Add(res);
            }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = threads, CancellationToken = cancellationToken });

            foreach (var i in documents)
            {
                actionBlock.Post(i);
            }
            actionBlock.Complete();
            await actionBlock.Completion;

            statsTimer?.Dispose();
            reportingCallback?.Invoke(cb.ToArray());
            return cb.ToArray();
        }


        #endregion
    }
    #endregion
}
