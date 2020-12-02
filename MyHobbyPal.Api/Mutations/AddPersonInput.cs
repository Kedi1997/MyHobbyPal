using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Mutations
{
    public class AddPersonInput
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public IList<string>? PhoneNumbers { get; set; } = new List<string>();

        public AddPersonInput(string givenName, string familyName, IList<string>? phoneNumbers)
        {
            GivenName = givenName;
            FamilyName = familyName;
            PhoneNumbers = phoneNumbers;
        }
    }
}
