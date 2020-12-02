using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Mutations
{
    public class UpdatePersonInput
    {
        public string PersonId { get; set; }
        public string PartitionKey { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
        public IList<string>? PhoneNumbers { get; set; } = new List<string>();

        public UpdatePersonInput(string personId, string partitionKey, string? givenName, string? familyName, IList<string>? phoneNumbers)
        {
            PersonId = personId;
            PartitionKey = partitionKey;
            GivenName = givenName;
            FamilyName = familyName;
            PhoneNumbers = phoneNumbers;
        }
    }
}
