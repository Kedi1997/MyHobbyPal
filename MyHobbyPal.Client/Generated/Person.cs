using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Person
        : IPerson
    {
        public Person(
            string givenName, 
            string familyName, 
            string partitionKey, 
            string personId, 
            IReadOnlyList<string> phoneNumbers)
        {
            GivenName = givenName;
            FamilyName = familyName;
            PartitionKey = partitionKey;
            PersonId = personId;
            PhoneNumbers = phoneNumbers;
        }

        public string GivenName { get; }

        public string FamilyName { get; }

        public string PartitionKey { get; }

        public string PersonId { get; }

        public IReadOnlyList<string> PhoneNumbers { get; }
    }
}
