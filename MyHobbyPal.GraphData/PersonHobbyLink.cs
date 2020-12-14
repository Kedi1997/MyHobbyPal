using CosmosDB.Net.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHobbyPal.GraphData
{
    #region PersonHobbyLink
    [Label(Value = nameof(Constant.EdgeLabel.HasHobby))]
    public class PersonHobbyLink
    {
        [Id]
        public string PersonHobbyId { get; set; }
        [PartitionKey]
        public string PartitionKey { get; set; }
        public int? YearsPracticed { get; set; }
        public double? ExpertiseAchieved { get; set; } 
    }
    #endregion
}
