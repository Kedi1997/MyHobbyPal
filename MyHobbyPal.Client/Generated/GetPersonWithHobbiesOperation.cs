using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetPersonWithHobbiesOperation
        : IOperation<IGetPersonWithHobbies>
    {
        public string Name => "getPersonWithHobbies";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetPersonWithHobbies);

        public Optional<string> PersonId { get; set; }

        public Optional<string> PartitionKey { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (PersonId.HasValue)
            {
                variables.Add(new VariableValue("personId", "String", PersonId.Value));
            }

            if (PartitionKey.HasValue)
            {
                variables.Add(new VariableValue("partitionKey", "String", PartitionKey.Value));
            }

            return variables;
        }
    }
}
