using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpdatePersonOperation
        : IOperation<IUpdatePerson>
    {
        public string Name => "updatePerson";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IUpdatePerson);

        public Optional<global::MyHobbyPal.Client.UpdatePersonInput> Person { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Person.HasValue)
            {
                variables.Add(new VariableValue("person", "UpdatePersonInput", Person.Value));
            }

            return variables;
        }
    }
}
