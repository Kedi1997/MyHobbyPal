using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHobbyPal.GraphData
{
    public interface IRepository
    {
        Task<Person> GetPersonById(string personId, string partitionKey);
       // Task<IList<Person>> GetPersonByName(string givenName, string familyName);
        Task<IList<Person>> GetAllPerson();
        Task UpsertHobbyForPerson(string personId, string partitionKey, Hobby hobby, PersonHobbyLink personHobbyLink);
        Task<IList<Hobby>> GetHobbiesForPerson(string personId, string partitionKey);
        Task<PersonHobbyLink> GetPersonHobbyLink(string partitionKey, string hobbyId);
        Task UpsertPerson(Person person);
    }
}