using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPerson1
    {
        string PartitionKey { get; }

        string PersonId { get; }

        string GivenName { get; }

        string FamilyName { get; }

        IReadOnlyList<string> PhoneNumbers { get; }
    }
}
