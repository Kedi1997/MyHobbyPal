using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Mutations
{
    public class UpsertPersonInput
    {
        public string? PersonId { get; set; }
        public string? PartitionKey { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
        public string[]? PhoneNumbers { get; set; } = Array.Empty<string>();

        public UpsertPersonInput(string personId, string partitionKey, string? givenName, string? familyName, string[] phoneNumbers)
        {
            PersonId = personId;
            PartitionKey = partitionKey;
            GivenName = givenName;
            FamilyName = familyName;
            PhoneNumbers = phoneNumbers;
        }
    }
}
