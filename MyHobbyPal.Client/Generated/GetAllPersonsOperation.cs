using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetAllPersonsOperation
        : IOperation<IGetAllPersons>
    {
        public string Name => "getAllPersons";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetAllPersons);

        public Optional<int?> First { get; set; }

        public Optional<string> After { get; set; }

        public Optional<int?> Last { get; set; }

        public Optional<string> Before { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (First.HasValue)
            {
                variables.Add(new VariableValue("first", "Int", First.Value));
            }

            if (After.HasValue)
            {
                variables.Add(new VariableValue("after", "String", After.Value));
            }

            if (Last.HasValue)
            {
                variables.Add(new VariableValue("last", "Int", Last.Value));
            }

            if (Before.HasValue)
            {
                variables.Add(new VariableValue("before", "String", Before.Value));
            }

            return variables;
        }
    }
}
