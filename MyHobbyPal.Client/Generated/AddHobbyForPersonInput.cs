using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AddHobbyForPersonInput
    {
        public Optional<double> Difficulty { get; set; }

        public Optional<double> ExpertiseAchieved { get; set; }

        public Optional<string> HobbyId { get; set; }

        public Optional<string> HobbyName { get; set; }

        public Optional<string> PartitionKey { get; set; }

        public Optional<string> PersonHobbyId { get; set; }

        public Optional<string> PersonId { get; set; }

        public Optional<int> YearsPracticed { get; set; }
    }
}
