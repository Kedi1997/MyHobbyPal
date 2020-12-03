using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class HobbyType
        : IHobbyType
    {
        public HobbyType(
            global::MyHobbyPal.Client.IHobby hobby, 
            int? yearsPracticed, 
            double? expertiseAchieved)
        {
            Hobby = hobby;
            YearsPracticed = yearsPracticed;
            ExpertiseAchieved = expertiseAchieved;
        }

        public global::MyHobbyPal.Client.IHobby Hobby { get; }

        public int? YearsPracticed { get; }

        public double? ExpertiseAchieved { get; }
    }
}
