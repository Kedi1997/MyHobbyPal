using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IMyHobbyPalClient
    {
        Task<IOperationResult<global::MyHobbyPal.Client.IGetAllPersons>> GetAllPersonsAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IGetAllPersons>> GetAllPersonsAsync(
            GetAllPersonsOperation operation,
            CancellationToken cancellationToken = default);
    }
}
