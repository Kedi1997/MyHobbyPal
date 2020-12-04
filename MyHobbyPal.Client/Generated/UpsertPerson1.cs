using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertPerson1
        : IUpsertPerson
    {
        public UpsertPerson1(
            global::MyHobbyPal.Client.IPersonPayload upsertPerson)
        {
            UpsertPerson = upsertPerson;
        }

        public global::MyHobbyPal.Client.IPersonPayload UpsertPerson { get; }
    }
}
