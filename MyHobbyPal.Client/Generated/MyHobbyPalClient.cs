using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class MyHobbyPalClient
        : IMyHobbyPalClient
    {
        private const string _clientName = "MyHobbyPalClient";

        private readonly global::StrawberryShake.IOperationExecutor _executor;

        public MyHobbyPalClient(global::StrawberryShake.IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IGetAllPersons>> GetAllPersonsAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetAllPersonsOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IGetAllPersons>> GetAllPersonsAsync(
            GetAllPersonsOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IGetPersonById>> GetPersonByIdAsync(
            global::StrawberryShake.Optional<string> personId = default,
            global::StrawberryShake.Optional<string> partitionKey = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (personId.HasValue && personId.Value is null)
            {
                throw new ArgumentNullException(nameof(personId));
            }

            if (partitionKey.HasValue && partitionKey.Value is null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }

            return _executor.ExecuteAsync(
                new GetPersonByIdOperation
                {
                    PersonId = personId, 
                    PartitionKey = partitionKey
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IGetPersonById>> GetPersonByIdAsync(
            GetPersonByIdOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IAddPerson>> AddPersonAsync(
            global::StrawberryShake.Optional<global::MyHobbyPal.Client.AddPersonInput> addperson = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (addperson.HasValue && addperson.Value is null)
            {
                throw new ArgumentNullException(nameof(addperson));
            }

            return _executor.ExecuteAsync(
                new AddPersonOperation { Addperson = addperson },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IAddPerson>> AddPersonAsync(
            AddPersonOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IUpdatePerson>> UpdatePersonAsync(
            global::StrawberryShake.Optional<global::MyHobbyPal.Client.UpdatePersonInput> person = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (person.HasValue && person.Value is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            return _executor.ExecuteAsync(
                new UpdatePersonOperation { Person = person },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IUpdatePerson>> UpdatePersonAsync(
            UpdatePersonOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IAddHobbyForPerson>> AddHobbyForPersonAsync(
            global::StrawberryShake.Optional<global::MyHobbyPal.Client.AddHobbyForPersonInput> addHobbyForPerson = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (addHobbyForPerson.HasValue && addHobbyForPerson.Value is null)
            {
                throw new ArgumentNullException(nameof(addHobbyForPerson));
            }

            return _executor.ExecuteAsync(
                new AddHobbyForPersonOperation { AddHobbyForPerson = addHobbyForPerson },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::MyHobbyPal.Client.IAddHobbyForPerson>> AddHobbyForPersonAsync(
            AddHobbyForPersonOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
