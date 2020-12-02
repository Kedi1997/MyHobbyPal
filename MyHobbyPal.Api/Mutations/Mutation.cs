using HotChocolate;
using MyHobbyPal.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Mutations
{
    public class Mutation
    {
        private readonly IRepository repository;

        public Mutation(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<PersonPayload> UpdatePersonAsync(UpdatePersonInput input)
        {
            var person = new Person
            {
                PartitionKey = input.PartitionKey,
                PersonId = input.PersonId,
                FamilyName = input.FamilyName,
                GivenName = input.GivenName,
                PhoneNumbers = input.PhoneNumbers
            };

            await repository.UpdatePerson(person);
            return new PersonPayload(person);
        }

        public async Task<PersonPayload> AddPersonAsync(AddPersonInput input)
        {
            var person = new Person
            {
                FamilyName = input.FamilyName,
                GivenName = input.GivenName,
                PhoneNumbers = input.PhoneNumbers
            };

            await repository.AddPerson(person);

            return new PersonPayload(person);
        }

        //public async Task<HobbyPayload> UpdateHobbyAsync(UpdateHobbyInput input)
        //{
        //    var hobby = new Hobby
        //    {
        //        HobbyId = input.HobbyId,
        //        PartitionKey = input.PartitionKey,
        //        Name = input.Name,
        //        Difficulty = input.Difficulty
        //    };
        //    await repository.UpdateHobby(hobby);
        //    return new HobbyPayload(hobby);
        //}

        //public async Task<HobbyPayload> AddHobbyAsync(AddHobbyInput input)
        //{
        //    var hobby = new Hobby
        //    {
        //        Name = input.Name,
        //        Difficulty = input.Difficulty
        //    };
        //    await repository.AddHobby(hobby);
        //    return new HobbyPayload(hobby);
        //}

        public async Task<AddHobbyForPersonPayload> UpsertHobbyForPerson(AddHobbyForPersonInput input)
        {
            var hobby = new Hobby
            {
                HobbyId = string.IsNullOrEmpty(input.HobbyId)? Guid.NewGuid().ToString("D"): input.HobbyId,
                PartitionKey = input.PartitionKey,
                Name = input.HobbyName,
                Difficulty = input.Difficulty
            };

            var personHobbyLink = new PersonHobbyLink
            {
                PersonHobbyId = string.IsNullOrEmpty(input.HobbyId) ? Guid.NewGuid().ToString("D") : input.PersonHobbyId,
                PartitionKey = input.PartitionKey,
                YearsPracticed = input.YearsPracticed,
                ExpertiseAchieved = input.ExpertiseAchieved
            };

            await repository.UpsertHobbyForPerson(input.PersonId, input.PartitionKey, hobby, personHobbyLink);
            return new AddHobbyForPersonPayload(hobby, personHobbyLink);
        }

    }
}
