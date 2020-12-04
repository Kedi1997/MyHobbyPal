using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AddPersonInput
    {
        public Optional<string> FamilyName { get; set; }

        public Optional<string> GivenName { get; set; }

        public Optional<IReadOnlyList<string>> PhoneNumbers { get; set; }
    }
}
