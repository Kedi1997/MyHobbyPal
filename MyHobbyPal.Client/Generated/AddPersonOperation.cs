using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AddPersonOperation
        : IOperation<IAddPerson>
    {
        public string Name => "addPerson";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IAddPerson);

        public Optional<global::MyHobbyPal.Client.AddPersonInput> Addperson { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Addperson.HasValue)
            {
                variables.Add(new VariableValue("addperson", "AddPersonInput", Addperson.Value));
            }

            return variables;
        }
    }
}
