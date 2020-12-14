using MyHobbyPal.Api.Types;
using MyHobbyPal.GraphData;

namespace MyHobbyPal.Api.Mutations
{
    public class UpsertHobbyForPersonPayload
    {
       public Types.Hobby HobbyType { get; set; }

        public UpsertHobbyForPersonPayload(Types.Hobby hobbyType)
        {
            HobbyType = hobbyType;
        }
    }
}