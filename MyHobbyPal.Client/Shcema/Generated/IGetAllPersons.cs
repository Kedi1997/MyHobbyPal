using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    public interface IGetAllPersons
    {
        IReadOnlyList<IPersonType> Persons { get; }
    }
}
