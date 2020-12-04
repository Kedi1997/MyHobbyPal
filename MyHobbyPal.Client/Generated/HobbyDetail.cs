﻿using System;
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
            global::MyHobbyPal.Client.IHobby hobby, 
            double? expertiseAchieved, 
            int? yearsPracticed)
        {
            Hobby = hobby;
            ExpertiseAchieved = expertiseAchieved;
            YearsPracticed = yearsPracticed;
        }

        public global::MyHobbyPal.Client.IHobby Hobby { get; }

        public double? ExpertiseAchieved { get; }

        public int? YearsPracticed { get; }
    }
}