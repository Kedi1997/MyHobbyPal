using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertHobbyForPerson1
        : IUpsertHobbyForPerson
    {
        public UpsertHobbyForPerson1(
            global::MyHobbyPal.Client.IUpsertHobbyForPersonPayload upsertHobbyForPerson)
        {
            UpsertHobbyForPerson = upsertHobbyForPerson;
        }

        public global::MyHobbyPal.Client.IUpsertHobbyForPersonPayload UpsertHobbyForPerson { get; }
    }
}
