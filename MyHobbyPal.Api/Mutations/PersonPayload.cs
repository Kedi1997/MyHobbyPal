using MyHobbyPal.Api.Types;
using MyHobbyPal.GraphData;

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
