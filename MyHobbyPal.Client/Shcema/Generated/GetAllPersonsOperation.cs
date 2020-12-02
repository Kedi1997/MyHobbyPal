using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    public class GetAllPersonsOperation
        : IOperation<IGetAllPersons>
    {
        public string Name => "getAllPersons";

        public IDocument Document => Queries.Default;

        public Type ResultType => typeof(IGetAllPersons);

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            return Array.Empty<VariableValue>();
        }
    }
}
