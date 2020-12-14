using MyHobbyPal.Api.Types;

namespace MyHobbyPal.Api.Mutations
{
    public class UpsertHobbyForPersonPayload
    {
       public Hobby Hobby { get; set; }

        public UpsertHobbyForPersonPayload(Hobby hobby)
        {
            Hobby = hobby;
        }
    }
}