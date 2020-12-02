using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    public class PersonType
        : IPersonType
    {
        public PersonType(
            string personId, 
            string partitionKey, 
            string familyName, 
            string givenName, 
            IReadOnlyList<string> phoneNumbers)
        {
            PersonId = personId;
            PartitionKey = partitionKey;
            FamilyName = familyName;
            GivenName = givenName;
            PhoneNumbers = phoneNumbers;
        }

        public string PersonId { get; }

        public string PartitionKey { get; }

        public string FamilyName { get; }

        public string GivenName { get; }

        public IReadOnlyList<string> PhoneNumbers { get; }
    }
}
