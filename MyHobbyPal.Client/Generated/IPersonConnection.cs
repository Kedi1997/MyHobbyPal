using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPersonConnection
    {
        global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonDetail> Nodes { get; }

        global::MyHobbyPal.Client.IPageInfo PageInfo { get; }
    }
}
