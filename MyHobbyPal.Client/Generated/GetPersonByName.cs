using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetPersonByName
        : IGetPersonByName
    {
        public GetPersonByName(
            global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonType2> person)
        {
            Person = person;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonType2> Person { get; }
    }
}
