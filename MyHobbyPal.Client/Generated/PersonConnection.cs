using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonConnection
        : IPersonConnection
    {
        public PersonConnection(
            global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonDetail> nodes, 
            global::MyHobbyPal.Client.IPageInfo pageInfo)
        {
            Nodes = nodes;
            PageInfo = pageInfo;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonDetail> Nodes { get; }

        public global::MyHobbyPal.Client.IPageInfo PageInfo { get; }
    }
}
