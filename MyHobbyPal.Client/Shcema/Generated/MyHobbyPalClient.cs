using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    public class MyHobbyPalClient
        : IMyHobbyPalClient
    {
        private readonly IOperationExecutor _executor;

        public MyHobbyPalClient(IOperationExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public Task<IOperationResult<IGetAllPersons>> GetAllPersonsAsync() =>
            GetAllPersonsAsync(CancellationToken.None);

        public Task<IOperationResult<IGetAllPersons>> GetAllPersonsAsync(
            CancellationToken cancellationToken)
        {

            return _executor.ExecuteAsync(
                new GetAllPersonsOperation(),
                cancellationToken);
        }
    }
}
