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
        private readonly IRepository repository;

        public Mutation(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        //public async Task<PersonPayload> UpdatePersonAsync(UpdatePersonInput input)
        //{
        //    var person = new Person
        //    {
        //        PartitionKey = input.PartitionKey,
        //        PersonId = input.PersonId,
        //        FamilyName = input.FamilyName,
        //        GivenName = input.GivenName,
        //        PhoneNumbers = input.PhoneNumbers
        //    };

        //    var personType = new PersonType
        //    {
        //        PartitionKey = input.PartitionKey,
        //        PersonId = input.PersonId,
        //        FamilyName = input.FamilyName,
        //        GivenName = input.GivenName,
        //        PhoneNumbers = input.PhoneNumbers
        //    };

        //    await repository.UpdatePerson(person);
        //    return new PersonPayload(personType);
        //}

        //public async Task<PersonPayload> AddPersonAsync(AddPersonInput input)
        //{
        //    var person = new Person
        //    {
        //        FamilyName = input.FamilyName,
        //        GivenName = input.GivenName,
        //        PhoneNumbers = input.PhoneNumbers
        //    };

        //    var personType = new PersonType
        //    {
        //        FamilyName = input.FamilyName,
        //        GivenName = input.GivenName,
        //        PhoneNumbers = input.PhoneNumbers
        //    };

        //    await repository.AddPerson(person);

        //    return new PersonPayload(personType);
        //}

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

            var personType = new PersonType
            {
                PartitionKey = input.PartitionKey,
                PersonId = input.PersonId,
                FamilyName = input.FamilyName,
                GivenName = input.GivenName,
                PhoneNumbers = input.PhoneNumbers
            };

            await repository.UpsertPerson(person);
            return new PersonPayload(personType);
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

        public async Task<UpsertHobbyForPersonPayload> UpsertHobbyForPerson(UpsertHobbyForPersonInput input)
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
                PersonHobbyId = string.IsNullOrEmpty(input.PersonHobbyId) ? Guid.NewGuid().ToString("D") : input.PersonHobbyId,
                PartitionKey = input.PartitionKey,
                YearsPracticed = input.YearsPracticed,
                ExpertiseAchieved = input.ExpertiseAchieved
            };

            await repository.UpsertHobbyForPerson(input.PersonId, input.PartitionKey, hobby, personHobbyLink);
            return new UpsertHobbyForPersonPayload(new HobbyType { Hobby = hobby, YearsPracticed=input.YearsPracticed, ExpertiseAchieved = input.ExpertiseAchieved }) ;
        }

    }
}
