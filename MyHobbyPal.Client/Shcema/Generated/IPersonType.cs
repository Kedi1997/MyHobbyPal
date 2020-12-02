using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    public interface IPersonType
    {
        string PersonId { get; }

        string PartitionKey { get; }

        string FamilyName { get; }

        string GivenName { get; }

        IReadOnlyList<string> PhoneNumbers { get; }
    }
}
