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

        Task<IOperationResult<global::MyHobbyPal.Client.IGetPersonById>> GetPersonByIdAsync(
            Optional<string> personId = default,
            Optional<string> partitionKey = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IGetPersonById>> GetPersonByIdAsync(
            GetPersonByIdOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpsertPerson>> UpsertPersonAsync(
            Optional<global::MyHobbyPal.Client.UpsertPersonInput> person = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpsertPerson>> UpsertPersonAsync(
            UpsertPersonOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpsertHobbyForPerson>> UpsertHobbyForPersonAsync(
            Optional<global::MyHobbyPal.Client.UpsertHobbyForPersonInput> addHobbyForPerson = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpsertHobbyForPerson>> UpsertHobbyForPersonAsync(
            UpsertHobbyForPersonOperation operation,
            CancellationToken cancellationToken = default);
    }
}
