using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class HobbyDetail
        : IHobbyDetail
    {
        public HobbyDetail(
            string hobbyId, 
            string partitionKey, 
            string name, 
            double? difficulty, 
            double? expertiseAchieved, 
            int? yearsPracticed, 
            string personHobbyId)
        {
            HobbyId = hobbyId;
            PartitionKey = partitionKey;
            Name = name;
            Difficulty = difficulty;
            ExpertiseAchieved = expertiseAchieved;
            YearsPracticed = yearsPracticed;
            PersonHobbyId = personHobbyId;
        }

        public string HobbyId { get; }

        public string PartitionKey { get; }

        public string Name { get; }

        public double? Difficulty { get; }

        public double? ExpertiseAchieved { get; }

        public int? YearsPracticed { get; }

        public string PersonHobbyId { get; }
    }
}
