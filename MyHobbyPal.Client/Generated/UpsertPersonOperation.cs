using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertPersonOperation
        : IOperation<IUpsertPerson>
    {
        public string Name => "UpsertPerson";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IUpsertPerson);

        public Optional<global::MyHobbyPal.Client.UpsertPersonInput> Person { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Person.HasValue)
            {
                variables.Add(new VariableValue("person", "UpsertPersonInput", Person.Value));
            }

            return variables;
        }
    }
}
