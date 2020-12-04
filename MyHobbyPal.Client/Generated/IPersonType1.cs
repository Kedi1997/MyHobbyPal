﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPersonType1
    {
        string PersonId { get; }

        string PartitionKey { get; }

        string FamilyName { get; }

        string GivenName { get; }

        IReadOnlyList<string> PhoneNumbers { get; }

        global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyType1> Hobbies { get; }
    }
}
