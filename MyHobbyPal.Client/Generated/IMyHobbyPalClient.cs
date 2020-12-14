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
            Optional<int?> first = default,
            Optional<string> after = default,
            Optional<int?> last = default,
            Optional<string> before = default,
            Optional<string> familyName = default,
            Optional<string> givenName = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IGetAllPersons>> GetAllPersonsAsync(
            GetAllPersonsOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IGetPersonWithHobbies>> GetPersonWithHobbiesAsync(
            Optional<string> personId = default,
            Optional<string> partitionKey = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IGetPersonWithHobbies>> GetPersonWithHobbiesAsync(
            GetPersonWithHobbiesOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpsertPerson>> UpsertPersonAsync(
            Optional<global::MyHobbyPal.Client.UpsertPersonInput> person = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpsertPerson>> UpsertPersonAsync(
            UpsertPersonOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpsertHobbyForPerson>> UpsertHobbyForPersonAsync(
            Optional<global::MyHobbyPal.Client.UpsertHobbyForPersonInput> upsertHobbyForPerson = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::MyHobbyPal.Client.IUpsertHobbyForPerson>> UpsertHobbyForPersonAsync(
            UpsertHobbyForPersonOperation operation,
            CancellationToken cancellationToken = default);
    }
}
