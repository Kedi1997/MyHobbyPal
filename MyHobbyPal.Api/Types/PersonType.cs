using MyHobbyPal.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Types
{
    public class PersonType
    {
        public PersonType()
        {
        }

        public PersonType(Person person)
        {
            Person = person;
        }

        //public string? PersonId { get; set; }
        //public string? PartitionKey { get; set; }
        //public string? GivenName { get; set; }
        //public string? FamilyName { get; set; }
        //public string[]? PhoneNumbers { get; set; }
        public Person? Person { get; set; }
        public IList<HobbyType>? Hobbies { get; set; } = new List<HobbyType>();


    }
}
