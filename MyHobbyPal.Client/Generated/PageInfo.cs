using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PageInfo
        : IPageInfo
    {
        public PageInfo(
            bool hasNextPage, 
            bool hasPreviousPage, 
            string startCursor, 
            string endCursor)
        {
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
            StartCursor = startCursor;
            EndCursor = endCursor;
        }

        public bool HasNextPage { get; }

        public bool HasPreviousPage { get; }

        public string StartCursor { get; }

        public string EndCursor { get; }
    }
}
