using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    public class GetAllPersons
        : IGetAllPersons
    {
        public GetAllPersons(
            IReadOnlyList<IPersonType> persons)
        {
            Persons = persons;
        }

        public IReadOnlyList<IPersonType> Persons { get; }
    }
}
