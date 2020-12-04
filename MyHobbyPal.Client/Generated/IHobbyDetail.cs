using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IHobbyDetail
    {
        global::MyHobbyPal.Client.IHobby Hobby { get; }

        double? ExpertiseAchieved { get; }

        int? YearsPracticed { get; }

        string PersonHobbyId { get; }
    }
}
