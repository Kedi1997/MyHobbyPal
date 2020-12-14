using AutoMapper;
using HotChocolate.Data;
using HotChocolate.Types;
using MyHobbyPal.Api.Types;
using MyHobbyPal.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Queries
{
    public class Query
    {
        #region Member Variables
        private readonly IRepository repository;
        #endregion

        #region Constructor
        public Query(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region GetPersons
        [UsePaging]
        [UseFiltering]
        [UseProjection]
        public async Task<IList<Person>> GetPersons()
        {
            //IList<Person> personTypes = new List<Person>();
            var persons = await repository.GetAllPerson();
            return persons;
            //foreach (Person person in persons)
            //{
            //    personTypes.Add(new PersonType(person));
            //}
            //return personTypes;
        }
        #endregion

        #region GetPersonWithHobbies
        public async Task<PersonWithHobbies> GetPersonWithHobbies(string? personId, string? partitionKey)
        {
            PersonWithHobbies personWithHobbies = new PersonWithHobbies();
            if (!string.IsNullOrEmpty(personId) && !string.IsNullOrEmpty(partitionKey))
            {
                var person = await repository.GetPersonById(personId, partitionKey);
                personWithHobbies = await GetHobbiesForPerson(person);
            }
            return personWithHobbies;
        }

        #endregion

        #region GetHobbiesForPerson
        private async Task<PersonWithHobbies> GetHobbiesForPerson(Person person)
        {
            IList<Types.Hobby> hobbies = new List<Types.Hobby>();

            foreach (var hobby in await repository.GetHobbiesForPerson(person.PersonId, person.PartitionKey))
            {
                var personHobbyLink = await repository.GetPersonHobbyLink(person.PartitionKey, hobby.HobbyId);
                hobbies.Add(new Types.Hobby
                {
                    HobbyId = hobby.HobbyId,
                    PartitionKey = hobby.PartitionKey,
                    Name = hobby.Name,
                    Difficulty = hobby.Difficulty,
                    YearsPracticed = personHobbyLink.YearsPracticed,
                    ExpertiseAchieved = personHobbyLink.ExpertiseAchieved,
                    PersonHobbyId = personHobbyLink.PersonHobbyId
                });
            }

            return new PersonWithHobbies
            {
                Person = person,
                Hobbies = hobbies
            };
        } 
        #endregion
    }

}
