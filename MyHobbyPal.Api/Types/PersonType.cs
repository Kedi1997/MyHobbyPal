using MyHobbyPal.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Types
{
    public class PersonType
    {
        public string PersonId { get; set; }
        public string PartitionKey { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public ICollection<string> PhoneNumbers { get; set; } = new List<string>();
        public IList<HobbyType> Hobbies { get; set; } = new List<HobbyType>();

        public PersonType()
        {

        }
    }
}
