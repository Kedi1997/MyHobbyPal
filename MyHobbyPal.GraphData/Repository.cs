using CosmosDB.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using System.Linq;

namespace MyHobbyPal.GraphData
{
    public class Repository : IRepository
    {
        #region Member variables
        private readonly string cosmosAccountName;
        private readonly string cosmosKey;
        private readonly string cosmosDatabaseId;
        private readonly string cosmosContainerId;
        private readonly string cosmosPartitionKeyPath;
        private readonly string environmentName;
        private ICosmosClientGraph cosmosClientGraph;
        //private readonly string gremlinElementMapCommand = "map(valueMap(true).unfold().group().by(keys).by(select(values).limit(local,1)))";
        #endregion

        #region Constructor
        public Repository(string cosmosAccountName, string cosmosKey, string cosmosDatabaseId, string cosmosContainerId, string cosmosPartitionKeyPath, string environmentName)
        {
            this.cosmosAccountName = cosmosAccountName;
            this.cosmosKey = cosmosKey;
            this.cosmosDatabaseId = cosmosDatabaseId;
            this.cosmosContainerId = cosmosContainerId;
            this.cosmosPartitionKeyPath = cosmosPartitionKeyPath;
            this.environmentName = environmentName;
        }
        #endregion

        #region Get Cosmos client graph
        public async Task<ICosmosClientGraph> GetCosmosClientGraph(string environmentName)
        {
            var createOptions = new CreateOptions(cosmosDatabaseId, cosmosContainerId, partitionKeyPath: cosmosPartitionKeyPath);
            cosmosClientGraph ??= await EdSmartCosmosClientGraph.GetClientWithSql(cosmosAccountName, cosmosKey, cosmosDatabaseId, cosmosContainerId, environmentName != Constant.EnvironmentName.LocalDevelopment, createOptions);
            return cosmosClientGraph;
        }
        #endregion

        #region GetPersonById
        public async Task<Person> GetPersonById(string personId, string partitionKey)
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var queryResult = await graph.ReadVertex<Person>(docId: personId, partitionKey: partitionKey);
            return queryResult.Result;
        }
        #endregion

        #region GetAllPerson
        public async Task<IList<Person>> GetAllPerson()
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var queryResult = await graph.ExecuteGremlin<Person>($"g.V().hasLabel('{Constant.VertexLabel.Person}')");

            return (IList<Person>)queryResult.Result;
        }
        #endregion

        #region UpsertHobbyForPerson
        public async Task UpsertHobbyForPerson(string personId, string partitionKey, Hobby hobby, PersonHobbyLink personHobbyLink)
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var personQuery = await graph.ReadVertex<Person>(personId, partitionKey);

            var queryResult = await graph.UpsertVertex<Hobby>(hobby);
            if (!queryResult.IsSuccessful) throw queryResult.Error;

            var upsertPersonHobbyLinkQuery = await graph.UpsertEdge(personHobbyLink, personQuery.Result, hobby);
            if (!upsertPersonHobbyLinkQuery.IsSuccessful) throw upsertPersonHobbyLinkQuery.Error;
        }
        #endregion

        #region GetHobbiesForPerson
        public async Task<IList<Hobby>> GetHobbiesForPerson(string personId, string partitionKey)
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var queryResult = await graph.ExecuteGremlin<Hobby>($"g.V().has('id','{personId}').outE().inV()");

            return (IList<Hobby>)queryResult.Result;
        }
        #endregion

        #region GetPersonHobbyLink
        public async Task<PersonHobbyLink> GetPersonHobbyLink(string partitionKey, string hobbyId)
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var queryResult = await graph.ExecuteGremlin<PersonHobbyLink>($"g.V().has('pk','{partitionKey}').outE().where(inV().has(id, '{hobbyId}'))");
            return (PersonHobbyLink)(PersonHobbyLink)queryResult.Result.First();
        }
        #endregion

        #region UpsertPerson
        public async Task UpsertPerson(Person person)
        {
            try
            {
                var graph = await GetCosmosClientGraph(environmentName);
                var queryResult = await graph.UpsertVertex<Person>(person);
                if (!queryResult.IsSuccessful) throw queryResult.Error;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion
    }
}
