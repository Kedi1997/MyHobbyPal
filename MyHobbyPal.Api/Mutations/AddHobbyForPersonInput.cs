namespace MyHobbyPal.Api.Mutations
{
    public class AddHobbyForPersonInput
    {
        public string PersonId { get; set; }
        public string PartitionKey { get; set; }
        public string HobbyName { get; set; }
        public double Difficulty { get; set; }
        public int YearsPracticed { get; set; }
        public double ExpertiseAchieved { get; set; }
        public string? HobbyId { get; set; }
        public string? PersonHobbyId { get; set; }

        public AddHobbyForPersonInput(string personId, string partitionKey, string hobbyName, double difficulty, int yearsPracticed, double expertiseAchieved, string hobbyId, string? personHobbyId)
        {
            PersonId = personId;
            PartitionKey = partitionKey;
            HobbyName = hobbyName;
            Difficulty = difficulty;
            YearsPracticed = yearsPracticed;
            ExpertiseAchieved = expertiseAchieved;
            HobbyId = hobbyId;
            PersonHobbyId = personHobbyId;
        }
    }
}