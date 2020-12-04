using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpdatePerson1
        : IUpdatePerson
    {
        public UpdatePerson1(
            global::MyHobbyPal.Client.IPersonPayload1 updatePerson)
        {
            UpdatePerson = updatePerson;
        }

        public global::MyHobbyPal.Client.IPersonPayload1 UpdatePerson { get; }
    }
}
