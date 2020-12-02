using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHobbyPal.GraphData
{
    public interface IRepository
    {
        public Task<Person> GetPersonById(string personId, string partitionKey);
        public Task<IList<Person>> GetPersonByName(string givenName, string familyName);
        public Task<IList<Person>> GetAllPerson();
        public Task AddPerson(Person person);
        public Task UpdatePerson(Person person);
        public Task AddHobby(Hobby hobby, string partitionKey, string hobbyId);
        public Task UpdateHobby(Hobby hobby);
        public Task<Hobby> GetHobbyById(string hobbyId, string partitionKey);
        public Task<IList<Hobby>> GetHobbyByName(string name);
        public Task<IList<Hobby>> GetAllHobby();
        public Task UpsertHobbyForPerson(string personId, string partitionKey, Hobby hobby, PersonHobbyLink personHobbyLink);
        Task<IList<Hobby>> GetPersonHobbies(string personId, string partitionKey);
        Task<PersonHobbyLink> GetPersonHobbyLink(string partitionKey, string hobbyId);
    }
}