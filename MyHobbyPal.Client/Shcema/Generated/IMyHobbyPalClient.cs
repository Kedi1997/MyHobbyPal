using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    public interface IMyHobbyPalClient
    {
        Task<IOperationResult<IGetAllPersons>> GetAllPersonsAsync();

        Task<IOperationResult<IGetAllPersons>> GetAllPersonsAsync(
            CancellationToken cancellationToken);
    }
}
