using MyHobbyPal.GraphData;

namespace MyHobbyPal.Api.Types
{
    public class Hobby
    {
        public string? HobbyId { get; set; }
        public string? PartitionKey { get; set; }
        public string? Name { get; set; }
        public double? Difficulty { get; set; }
        public int? YearsPracticed { get; set; }
        public double? ExpertiseAchieved { get; set; }
        public string? PersonHobbyId { get; set; }

    }
}