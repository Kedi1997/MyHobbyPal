using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonType
        : IPersonType
    {
        public PersonType(
            global::MyHobbyPal.Client.IPersonDetail person, 
            global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyDetail> hobbies)
        {
            Person = person;
            Hobbies = hobbies;
        }

        public global::MyHobbyPal.Client.IPersonDetail Person { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyDetail> Hobbies { get; }
    }
}
