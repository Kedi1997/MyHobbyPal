using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AddHobbyForPersonOperation
        : IOperation<IAddHobbyForPerson>
    {
        public string Name => "addHobbyForPerson";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IAddHobbyForPerson);

        public Optional<global::MyHobbyPal.Client.AddHobbyForPersonInput> AddHobbyForPerson { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (AddHobbyForPerson.HasValue)
            {
                variables.Add(new VariableValue("addHobbyForPerson", "AddHobbyForPersonInput", AddHobbyForPerson.Value));
            }

            return variables;
        }
    }
}
