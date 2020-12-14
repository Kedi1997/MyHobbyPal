using CosmosDB.Net.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHobbyPal.GraphData
{
    #region Hobby
    [Label(Value = nameof(Constant.VertexLabel.Hobby))]
    public class Hobby
    {
        [Id]
        public string HobbyId { get; set; }
        [PartitionKey]
        public string PartitionKey { get; set; }
        public string Name { get; set; }
        public double? Difficulty { get; set; }
    }
    #endregion
}
