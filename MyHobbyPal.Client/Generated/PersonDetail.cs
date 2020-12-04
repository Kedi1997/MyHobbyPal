using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonDetail
        : IPersonDetail
    {
        public PersonDetail(
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
