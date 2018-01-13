using System;
using System.Threading;
using System.Threading.Tasks;
namespace InFurSec.FlatApp.Core
{
    public interface IAuthClient
    {
        Task<bool> HasTokenExpiredAsync(string jwt, CancellationToken cancellationToken = default);
    }
}
