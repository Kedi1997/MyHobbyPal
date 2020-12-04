using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Hobby1
        : IHobby1
    {
        public Hobby1(
            string name, 
            double? difficulty)
        {
            Name = name;
            Difficulty = difficulty;
        }

        public string Name { get; }

        public double? Difficulty { get; }
    }
}
