using System;
using System.Threading;
using System.Threading.Tasks;

namespace InFurSec.FlatApp.Shared
{
    public interface ITokenClient
    {
        Task<string> LoginAsync(CancellationToken cancellationToken = default);
        Task<string> RefreshAccessTokenAsync(CancellationToken cancellationToken = default);
        Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default);
    }
}
