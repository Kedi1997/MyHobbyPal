using MyHobbyPal.GraphData;

namespace MyHobbyPal.Api.Mutations
{
    public class AddHobbyForPersonPayload
    {
        public Hobby Hobby { get; }
        public PersonHobbyLink PersonHobbyLink { get; }

        public AddHobbyForPersonPayload(Hobby hobby, PersonHobbyLink personHobbyLink)
        {
            Hobby = hobby;
            PersonHobbyLink = personHobbyLink;
        }
    }
}