using AutoMapper;
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
        private readonly IRepository repository;

        public Query(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IList<PersonType>> GetPersons()
        {
            //return (IList<PersonType>)await repository.GetAllPerson();
            IList<PersonType> personTypes = new List<PersonType>();
            var persons = await repository.GetAllPerson();

            foreach(Person person in persons)
            {
                personTypes.Add(await GetPersonTypeExtensionsAsync(person));
            }
            return personTypes;
        }

        public async Task<IList<PersonType>> GetPerson(string? personId, string? partitionKey, string? givenName, string? familyName)
        {
            IList<PersonType> personTypes = new List<PersonType>();
            if(!string.IsNullOrEmpty(personId) && !string.IsNullOrEmpty(partitionKey))
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
            //return await repository.GetPersonById(personId, partitionKey);
        }

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
                    ExpertiseAchieved = personHobbyLink.ExpertiseAchieved
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

        //public async Task<IList<PersonType>> GetPersonByName(string? givenName, string? familyName)
        //{
        //    //return await repository.GetPersonByName(givenName, familyName);
        //    IList<PersonType> personTypes = new List<PersonType>();
        //    var persons = await repository.GetPersonByName(givenName, familyName);

        //    foreach (Person person in persons)
        //    {
        //        IList<HobbyType> hobbies = new List<HobbyType>();

        //        foreach (var hobby in await repository.GetPersonHobbies(person.PersonId, person.PartitionKey))
        //        {
        //            var personHobbyLink = await repository.GetPersonHobbyLink(person.PartitionKey, hobby.HobbyId);
        //            hobbies.Add(new HobbyType
        //            {
        //                Hobby = hobby,
        //                YearsPracticed = personHobbyLink.YearsPracticed,
        //                ExpertiseAchieved = personHobbyLink.ExpertiseAchieved
        //            });
        //        }

        //        personTypes.Add(new PersonType
        //        {
        //            PersonId = person.PersonId,
        //            PartitionKey = person.PartitionKey,
        //            FamilyName = person.FamilyName,
        //            GivenName = person.GivenName,
        //            PhoneNumbers = person.PhoneNumbers,
        //            Hobbies = hobbies
        //        });
        //    }
        //    return personTypes;
        //}

        //public async Task<IEnumerable<Hobby>> GetHobbies()
        //{
        //    return await repository.GetAllHobby();
        //}

        //public async Task<Hobby> GetHobbyById(string? hobbyId, string? partitionKey)
        //{
        //    return await repository.GetHobbyById(hobbyId, partitionKey);
        //}

        //public async Task<IList<Hobby>> GetHobbyByName(string? name)
        //{
        //    return await repository.GetHobbyByName(name);
        //}
    }

}
