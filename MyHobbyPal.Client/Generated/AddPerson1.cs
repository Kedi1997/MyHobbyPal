using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AddPerson1
        : IAddPerson
    {
        public AddPerson1(
            global::MyHobbyPal.Client.IPersonPayload addPerson)
        {
            AddPerson = addPerson;
        }

        public global::MyHobbyPal.Client.IPersonPayload AddPerson { get; }
    }
}
