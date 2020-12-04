using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AddHobbyForPersonPayload
        : IAddHobbyForPersonPayload
    {
        public AddHobbyForPersonPayload(
            global::MyHobbyPal.Client.IHobby2 hobby, 
            global::MyHobbyPal.Client.IPersonHobbyLink personHobbyLink)
        {
            Hobby = hobby;
            PersonHobbyLink = personHobbyLink;
        }

        public global::MyHobbyPal.Client.IHobby2 Hobby { get; }

        public global::MyHobbyPal.Client.IPersonHobbyLink PersonHobbyLink { get; }
    }
}
