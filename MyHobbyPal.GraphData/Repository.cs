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

        public async Task<Person> GetPersonById(string personId, string partitionKey)
        {
            var graph = await GetCosmosClientGraph(environmentName);

            var queryResult = await graph.ReadVertex<Person>(docId: personId, partitionKey: partitionKey);
            return queryResult.Result;
        }

        public async Task<IList<Person>> GetPersonByName(string givenName, string familyName)
        {
            var graph = await GetCosmosClientGraph(environmentName);

            if (!string.IsNullOrEmpty(givenName) && !string.IsNullOrEmpty(familyName))
            {
                var queryResult = await graph.ExecuteGremlin<Person>($"g.V().HasLabel('{Constant.VertexLabel.Person}').has('{Constant.FieldName.GivenName}','{givenName}').has('{Constant.FieldName.FamilyName}','{familyName}')");
                return (IList<Person>)queryResult.Result;
            }
            else if(!string.IsNullOrEmpty(givenName) && string.IsNullOrEmpty(familyName))
            {
                var queryResult = await graph.ExecuteGremlin<Person>($"g.V().HasLabel('{Constant.VertexLabel.Person}').has('{Constant.FieldName.GivenName}','{givenName}')");
                return (IList<Person>)queryResult.Result;
            }
            else if (string.IsNullOrEmpty(givenName) && !string.IsNullOrEmpty(familyName))
            {
                var queryResult = await graph.ExecuteGremlin<Person>($"g.V().HasLabel('{Constant.VertexLabel.Person}').has('{Constant.FieldName.FamilyName}','{familyName}')");
                return (IList<Person>)queryResult.Result;
            }
            return new List<Person>();
        }

        public async Task<IList<Person>> GetAllPerson()
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var queryResult = await graph.ExecuteGremlin<Person>($"g.V().hasLabel('{Constant.VertexLabel.Person}')");

            return (IList<Person>)queryResult.Result;
        }

        //public async Task AddPerson(Person person)
        //{
        //    try
        //    {
        //        var graph = await GetCosmosClientGraph(environmentName);
        //        person.PersonId = Guid.NewGuid().ToString("D");
        //        person.PartitionKey = Guid.NewGuid().ToString("D");

        //        var queryResult = await graph.UpsertVertex<Person>(person);
        //        if (!queryResult.IsSuccessful) throw queryResult.Error;
        //    }
        //    catch (Exception ex)
        //    {
        //        var baseEx = ex.GetBaseException();
        //        throw;
        //    }
        //}

        //public async Task UpdatePerson(Person person)
        //{
        //    try
        //    {
        //        var graph = await GetCosmosClientGraph(environmentName);
        //        var queryResult = await graph.UpsertVertex<Person>(person);
        //        if (!queryResult.IsSuccessful) throw queryResult.Error;
        //    }
        //    catch(Exception ex)
        //    {
        //        var baseEx = ex.GetBaseException();
        //        throw;
        //    }
        //}

        //public async Task AddHobby(Hobby hobby, string hobbyId, string partitionKey)
        //{
        //    try
        //    {
        //        var graph = await GetCosmosClientGraph(environmentName);
        //        hobby.HobbyId = hobbyId;
        //        hobby.PartitionKey = partitionKey;

        //        var queryResult = await graph.UpsertVertex<Hobby>(hobby);
        //        if (!queryResult.IsSuccessful) throw queryResult.Error;
        //    }
        //    catch (Exception ex)
        //    {
        //        var baseEx = ex.GetBaseException();
        //        throw;
        //    }
        //}
        //public async Task UpdateHobby(Hobby hobby)
        //{
        //    try
        //    {
        //        var graph = await GetCosmosClientGraph(environmentName);
        //        var queryResult = await graph.UpsertVertex<Hobby>(hobby);
        //        if (!queryResult.IsSuccessful) throw queryResult.Error;
        //    }
        //    catch (Exception ex)
        //    {
        //        var baseEx = ex.GetBaseException();
        //        throw;
        //    }
        //}

        //public async Task<Hobby> GetHobbyById(string hobbyId, string partitionKey)
        //{
        //    var graph = await GetCosmosClientGraph(environmentName);
        //    var queryResult = await graph.ReadVertex<Hobby>(docId: hobbyId, partitionKey: partitionKey);
        //    return queryResult.Result;
        //}

        //public async Task<IList<Hobby>> GetHobbyByName(string name)
        //{
        //    var graph = await GetCosmosClientGraph(environmentName);
        //    var queryResult = await graph.ExecuteGremlin<Hobby>($"g.V().HasLabel('{Constant.VertexLabel.Hobby}').has('{Constant.FieldName.Name}','{name}')");
        //    return (IList<Hobby>)queryResult.Result;
        //}

        //public async Task<IList<Hobby>> GetAllHobby()
        //{
        //    var graph = await GetCosmosClientGraph(environmentName);
        //    var sql = $"SELECT * FROM c where c.label = '{Constant.VertexLabel.Hobby}'";
        //    var queryResult = await graph.ExecuteGremlin<Hobby>($"g.V().hasLabel('{Constant.VertexLabel.Hobby}')");

        //    return (IList<Hobby>)queryResult.Result;
        //}

        public async Task UpsertHobbyForPerson(string personId, string partitionKey, Hobby hobby, PersonHobbyLink personHobbyLink)
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var personQuery = await graph.ReadVertex<Person>(personId, partitionKey);

            var queryResult = await graph.UpsertVertex<Hobby>(hobby);
            if (!queryResult.IsSuccessful) throw queryResult.Error;

            var upsertPersonHobbyLinkQuery = await graph.UpsertEdge(personHobbyLink, personQuery.Result, hobby);
            if (!upsertPersonHobbyLinkQuery.IsSuccessful) throw upsertPersonHobbyLinkQuery.Error;
        }

        public async Task<IList<Hobby>> GetPersonHobbies(string personId, string partitionKey)
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var queryResult = await graph.ExecuteGremlin<Hobby>($"g.V().has('id','{personId}').outE().inV()");

            return (IList<Hobby>)queryResult.Result;
        }

        public async Task<PersonHobbyLink> GetPersonHobbyLink(string partitionKey, string hobbyId)
        {
            var graph = await GetCosmosClientGraph(environmentName);
            var queryResult = await graph.ExecuteGremlin<PersonHobbyLink>($"g.V().has('pk','{partitionKey}').outE().where(inV().has(id, '{hobbyId}'))");
            return (PersonHobbyLink)(PersonHobbyLink)queryResult.Result.First();
        }

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
                //var baseEx = ex.GetBaseException();
                throw;
            }
        }
    }
}
