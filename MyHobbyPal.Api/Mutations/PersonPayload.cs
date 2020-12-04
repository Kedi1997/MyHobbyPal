using MyHobbyPal.Api.Types;
using MyHobbyPal.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Mutations
{
    public class PersonPayload
    {
        public PersonType PersonType { get; }

        public PersonPayload(PersonType personType)
        {
            PersonType = personType;
        }
                
    }
}
