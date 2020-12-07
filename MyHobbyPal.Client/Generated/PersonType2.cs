using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonType2
        : IPersonType2
    {
        public PersonType2(
            global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyDetail> hobbies, 
            string personId, 
            string partitionKey, 
            string familyName, 
            string givenName, 
            IReadOnlyList<string> phoneNumbers)
        {
            Hobbies = hobbies;
            PersonId = personId;
            PartitionKey = partitionKey;
            FamilyName = familyName;
            GivenName = givenName;
            PhoneNumbers = phoneNumbers;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyDetail> Hobbies { get; }

        public string PersonId { get; }

        public string PartitionKey { get; }

        public string FamilyName { get; }

        public string GivenName { get; }

        public IReadOnlyList<string> PhoneNumbers { get; }
    }
}
