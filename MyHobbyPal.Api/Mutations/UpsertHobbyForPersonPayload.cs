using MyHobbyPal.Api.Types;
using MyHobbyPal.GraphData;

namespace MyHobbyPal.Api.Mutations
{
    public class UpsertHobbyForPersonPayload
    {
       public HobbyType HobbyType { get; set; }

        public UpsertHobbyForPersonPayload(HobbyType hobbyType)
        {
            HobbyType = hobbyType;
        }
    }
}