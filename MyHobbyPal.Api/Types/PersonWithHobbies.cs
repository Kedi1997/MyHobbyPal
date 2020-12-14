using MyHobbyPal.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.Api.Types
{
    public class PersonWithHobbies
    {
        public PersonWithHobbies()
        {
        }

        public Person? Person { get; set; }
        public IList<Hobby>? Hobbies { get; set; } = new List<Hobby>();


    }
}
