using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetPersonWithHobbies
        : IGetPersonWithHobbies
    {
        public GetPersonWithHobbies(
            global::MyHobbyPal.Client.IPersonWithHobbies personWithHobbies)
        {
            PersonWithHobbies = personWithHobbies;
        }

        public global::MyHobbyPal.Client.IPersonWithHobbies PersonWithHobbies { get; }
    }
}
