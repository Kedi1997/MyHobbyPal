using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetPersonByNameOperation
        : IOperation<IGetPersonByName>
    {
        public string Name => "getPersonByName";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetPersonByName);

        public Optional<string> GivenName { get; set; }

        public Optional<string> FamilyName { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (GivenName.HasValue)
            {
                variables.Add(new VariableValue("givenName", "String", GivenName.Value));
            }

            if (FamilyName.HasValue)
            {
                variables.Add(new VariableValue("familyName", "String", FamilyName.Value));
            }

            return variables;
        }
    }
}
