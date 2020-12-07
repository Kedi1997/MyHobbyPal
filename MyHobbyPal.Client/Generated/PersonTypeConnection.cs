using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonTypeConnection
        : IPersonTypeConnection
    {
        public PersonTypeConnection(
            global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonType> nodes, 
            global::MyHobbyPal.Client.IPageInfo pageInfo)
        {
            Nodes = nodes;
            PageInfo = pageInfo;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonType> Nodes { get; }

        public global::MyHobbyPal.Client.IPageInfo PageInfo { get; }
    }
}
