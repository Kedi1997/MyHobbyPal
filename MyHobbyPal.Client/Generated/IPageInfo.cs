using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPageInfo
    {
        bool HasNextPage { get; }

        bool HasPreviousPage { get; }

        string StartCursor { get; }

        string EndCursor { get; }
    }
}
