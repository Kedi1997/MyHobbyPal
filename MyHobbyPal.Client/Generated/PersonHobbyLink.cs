using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonHobbyLink
        : IPersonHobbyLink
    {
        public PersonHobbyLink(
            double expertiseAchieved, 
            int yearsPracticed)
        {
            ExpertiseAchieved = expertiseAchieved;
            YearsPracticed = yearsPracticed;
        }

        public double ExpertiseAchieved { get; }

        public int YearsPracticed { get; }
    }
}
