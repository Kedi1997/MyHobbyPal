using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertHobbyForPersonPayload
        : IUpsertHobbyForPersonPayload
    {
        public UpsertHobbyForPersonPayload(
            global::MyHobbyPal.Client.IHobbyDetail hobbyType)
        {
            HobbyType = hobbyType;
        }

        public global::MyHobbyPal.Client.IHobbyDetail HobbyType { get; }
    }
}
