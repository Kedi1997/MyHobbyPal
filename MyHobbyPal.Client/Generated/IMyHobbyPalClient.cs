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

        Task<IOperationResult<global::MyHobbyPal.Client.IAddPerson>> AddPersonAsync(
            Optional<global::MyHobbyPal.Client.AddPersonInput> addperson = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IAddPerson>> AddPersonAsync(
            AddPersonOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpdatePerson>> UpdatePersonAsync(
            Optional<global::MyHobbyPal.Client.UpdatePersonInput> person = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpdatePerson>> UpdatePersonAsync(
            UpdatePersonOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IAddHobbyForPerson>> AddHobbyForPersonAsync(
            Optional<global::MyHobbyPal.Client.AddHobbyForPersonInput> addHobbyForPerson = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IAddHobbyForPerson>> AddHobbyForPersonAsync(
            AddHobbyForPersonOperation operation,
            CancellationToken cancellationToken = default);
    }
}
