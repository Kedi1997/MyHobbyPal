﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonType1
        : IPersonType1
    {
        public PersonType1(
            global::MyHobbyPal.Client.IPersonDetail person)
        {
            Person = person;
        }

        public global::MyHobbyPal.Client.IPersonDetail Person { get; }
    }
}
