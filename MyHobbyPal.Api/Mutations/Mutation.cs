using HotChocolate;
using MyHobbyPal.Api.Types;
using MyHobbyPal.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Mutations
{
    public class Mutation
    {
        #region Member Variables
        private readonly IRepository repository;
        #endregion

        #region Constructor
        public Mutation(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region UpsertPersonAsync
        public async Task<PersonPayload> UpsertPersonAsync(UpsertPersonInput input)
        {
            if (string.IsNullOrEmpty(input.PersonId) && string.IsNullOrEmpty(input.PartitionKey))
            {
                input.PersonId = Guid.NewGuid().ToString("D");
                input.PartitionKey = Guid.NewGuid().ToString("D");
            }
            var person = new Person
            {
                PartitionKey = input.PartitionKey,
                PersonId = input.PersonId,
                FamilyName = input.FamilyName,
                GivenName = input.GivenName,
                PhoneNumbers = input.PhoneNumbers
            };

            var personType = new PersonWithHobbies
            {
                //PartitionKey = input.PartitionKey,
                //PersonId = input.PersonId,
                //FamilyName = input.FamilyName,
                //GivenName = input.GivenName,
                //PhoneNumbers = input.PhoneNumbers
                Person = person
            };

            await repository.UpsertPerson(person);
            return new PersonPayload(personType);
        }
        #endregion

        #region UpsertHobbyForPerson
        public async Task<UpsertHobbyForPersonPayload> UpsertHobbyForPerson(UpsertHobbyForPersonInput input)
        {
            var hobby = new GraphData.Hobby
            {
                HobbyId = string.IsNullOrEmpty(input.HobbyId) ? Guid.NewGuid().ToString("D") : input.HobbyId,
                PartitionKey = input.PartitionKey,
                Name = input.HobbyName,
                Difficulty = input.Difficulty
            };

            var personHobbyLink = new PersonHobbyLink
            {
                PersonHobbyId = string.IsNullOrEmpty(input.PersonHobbyId) ? Guid.NewGuid().ToString("D") : input.PersonHobbyId,
                PartitionKey = input.PartitionKey,
                YearsPracticed = input.YearsPracticed,
                ExpertiseAchieved = input.ExpertiseAchieved
            };

            await repository.UpsertHobbyForPerson(input.PersonId, input.PartitionKey, hobby, personHobbyLink);
            return new UpsertHobbyForPersonPayload(new Types.Hobby
            {
                HobbyId = hobby.HobbyId,
                PartitionKey = hobby.PartitionKey,
                Name = hobby.Name,
                Difficulty = hobby.Difficulty,
                YearsPracticed = input.YearsPracticed, 
                ExpertiseAchieved = input.ExpertiseAchieved 
            });
        } 
        #endregion

    }
}
