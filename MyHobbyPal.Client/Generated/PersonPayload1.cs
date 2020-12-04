using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonPayload1
        : IPersonPayload1
    {
        public PersonPayload1(
            global::MyHobbyPal.Client.IPerson1 person)
        {
            Person = person;
        }

        public global::MyHobbyPal.Client.IPerson1 Person { get; }
    }
}
