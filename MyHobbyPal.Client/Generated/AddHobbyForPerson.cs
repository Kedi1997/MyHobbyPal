using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AddHobbyForPerson
        : IAddHobbyForPerson
    {
        public AddHobbyForPerson(
            global::MyHobbyPal.Client.IAddHobbyForPersonPayload upsertHobbyForPerson)
        {
            UpsertHobbyForPerson = upsertHobbyForPerson;
        }

        public global::MyHobbyPal.Client.IAddHobbyForPersonPayload UpsertHobbyForPerson { get; }
    }
}
