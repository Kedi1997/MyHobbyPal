using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertHobbyForPersonOperation
        : IOperation<IUpsertHobbyForPerson>
    {
        public string Name => "upsertHobbyForPerson";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IUpsertHobbyForPerson);

        public Optional<global::MyHobbyPal.Client.UpsertHobbyForPersonInput> AddHobbyForPerson { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (AddHobbyForPerson.HasValue)
            {
                variables.Add(new VariableValue("addHobbyForPerson", "UpsertHobbyForPersonInput", AddHobbyForPerson.Value));
            }

            return variables;
        }
    }
}
