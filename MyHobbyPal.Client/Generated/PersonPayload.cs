﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonPayload
        : IPersonPayload
    {
        public PersonPayload(
            global::MyHobbyPal.Client.IPersonDetail person)
        {
            Person = person;
        }

        public global::MyHobbyPal.Client.IPersonDetail Person { get; }
    }
}
