using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Person1
        : IPerson1
    {
        public Person1(
            string partitionKey, 
            string personId, 
            string givenName, 
            string familyName, 
            IReadOnlyList<string> phoneNumbers)
        {
            PartitionKey = partitionKey;
            PersonId = personId;
            GivenName = givenName;
            FamilyName = familyName;
            PhoneNumbers = phoneNumbers;
        }

        public string PartitionKey { get; }

        public string PersonId { get; }

        public string GivenName { get; }

        public string FamilyName { get; }

        public IReadOnlyList<string> PhoneNumbers { get; }
    }
}
