using MyHobbyPal.Api.Types;
using MyHobbyPal.GraphData;

namespace MyHobbyPal.Api.Mutations
{
    public class AddHobbyForPersonPayload
    {
       public HobbyType HobbyType { get; set; }

        public AddHobbyForPersonPayload(HobbyType hobbyType)
        {
            HobbyType = hobbyType;
        }
    }
}