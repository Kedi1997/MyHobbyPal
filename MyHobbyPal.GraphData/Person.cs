﻿using CosmosDB.Net.Domain.Attributes;
using System.Collections.Generic;

namespace MyHobbyPal.GraphData
{
    #region Person
    [Label(Value = nameof(Constant.VertexLabel.Person))]
    public class Person
    {
        [Id]
        public string PersonId { get; set; }
        [PartitionKey]
        public string PartitionKey { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string[] PhoneNumbers { get; set; } = new string[] { };
    } 
    #endregion
}
