using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPersonWithHobbies
    {
        global::MyHobbyPal.Client.IPersonDetail Person { get; }

        global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyDetail> Hobbies { get; }
    }
}
