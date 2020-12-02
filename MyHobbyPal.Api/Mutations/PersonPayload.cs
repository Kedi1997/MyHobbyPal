using MyHobbyPal.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Mutations
{
    public class PersonPayload
    {
        public Person Person { get; }

        public PersonPayload(Person person)
        {
            Person = person;
        }
                
    }
}
