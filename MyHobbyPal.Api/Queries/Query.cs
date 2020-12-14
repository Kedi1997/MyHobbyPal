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

        #region GetPersonByName
        public async Task<IList<Person>> GetPersonByName(string? givenName, string? familyName)
        {
            //IList<Person> personTypes = new List<Person>();
            var persons = await repository.GetPersonByName(givenName, familyName);
            return persons;
        }
        #endregion

        #region GetPersonHobbies
        public async Task<PersonType> GetPersonHobbies(string? personId, string? partitionKey)
        {
            PersonType personType = new PersonType();
            if (!string.IsNullOrEmpty(personId) && !string.IsNullOrEmpty(partitionKey))
            {
                var person = await repository.GetPersonById(personId, partitionKey);
                personType = await GetPersonTypeExtensionsAsync(person);
            }
            return personType;
        }

            #endregion

            #region GetPersonTypeExtensionsAsync
            private async Task<PersonType> GetPersonTypeExtensionsAsync(Person person)
        {
            IList<HobbyType> hobbies = new List<HobbyType>();

            foreach (var hobby in await repository.GetPersonHobbies(person.PersonId, person.PartitionKey))
            {
                var personHobbyLink = await repository.GetPersonHobbyLink(person.PartitionKey, hobby.HobbyId);
                hobbies.Add(new HobbyType
                {
                    Hobby = hobby,
                    YearsPracticed = personHobbyLink.YearsPracticed,
                    ExpertiseAchieved = personHobbyLink.ExpertiseAchieved,
                    PersonHobbyId = personHobbyLink.PersonHobbyId
                });
            }

            return new PersonType
            {
                Person = person,
                Hobbies = hobbies
            };
        } 
        #endregion
    }

}
