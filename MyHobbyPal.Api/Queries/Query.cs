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
        public async Task<IList<PersonType>> GetPersons()
        {
            IList<PersonType> personTypes = new List<PersonType>();
            var persons = await repository.GetAllPerson();

            foreach (Person person in persons)
            {
                personTypes.Add(await GetPersonTypeExtensionsAsync(person));
            }
            return personTypes;
        }
        #endregion

        #region GetPerson
        public async Task<IList<PersonType>> GetPerson(string? personId, string? partitionKey, string? givenName, string? familyName)
        {
            IList<PersonType> personTypes = new List<PersonType>();
            if (!string.IsNullOrEmpty(personId) && !string.IsNullOrEmpty(partitionKey))
            {
                var person = await repository.GetPersonById(personId, partitionKey);
                personTypes.Add(await GetPersonTypeExtensionsAsync(person));
            }
            else
            {
                var persons = await repository.GetPersonByName(givenName, familyName);
                foreach (Person person in persons)
                {
                    personTypes.Add(await GetPersonTypeExtensionsAsync(person));
                }
            }
            return personTypes;
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
                PersonId = person.PersonId,
                PartitionKey = person.PartitionKey,
                FamilyName = person.FamilyName,
                GivenName = person.GivenName,
                PhoneNumbers = person.PhoneNumbers,
                Hobbies = hobbies
            };
        } 
        #endregion
    }

}
