using MyHobbyPal.GraphData;

namespace MyHobbyPal.Api.Types
{
    public class HobbyType
    {
        public Hobby Hobby { get; set; }
        public int YearsPracticed { get; set; }
        public double ExpertiseAchieved { get; set; }

        public HobbyType()
        {

        }
    }
}