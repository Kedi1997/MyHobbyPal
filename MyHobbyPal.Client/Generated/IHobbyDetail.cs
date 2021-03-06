﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IHobbyDetail
    {
        string HobbyId { get; }

        string PartitionKey { get; }

        string Name { get; }

        double? Difficulty { get; }

        double? ExpertiseAchieved { get; }

        int? YearsPracticed { get; }

        string PersonHobbyId { get; }
    }
}
