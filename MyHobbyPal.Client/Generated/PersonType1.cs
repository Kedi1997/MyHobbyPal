using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonType1
        : IPersonType1
    {
        public PersonType1(
            string personId, 
            string partitionKey, 
            string familyName, 
            string givenName, 
            IReadOnlyList<string> phoneNumbers, 
            global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyType1> hobbies)
        {
            PersonId = personId;
            PartitionKey = partitionKey;
            FamilyName = familyName;
            GivenName = givenName;
            PhoneNumbers = phoneNumbers;
            Hobbies = hobbies;
        }

        public string PersonId { get; }

        public string PartitionKey { get; }

        public string FamilyName { get; }

        public string GivenName { get; }

        public IReadOnlyList<string> PhoneNumbers { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyType1> Hobbies { get; }
    }
}
