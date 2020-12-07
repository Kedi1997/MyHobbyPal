using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetAllPersons
        : IGetAllPersons
    {
        public GetAllPersons(
            global::MyHobbyPal.Client.IPersonTypeConnection persons)
        {
            Persons = persons;
        }

        public global::MyHobbyPal.Client.IPersonTypeConnection Persons { get; }
    }
}
