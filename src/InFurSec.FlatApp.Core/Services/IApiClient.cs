using System;
using System.Threading;
using System.Threading.Tasks;

namespace InFurSec.FlatApp.Core
{
    public interface IApiClient
    {
        Task<string> RawQueryAsync(string query, string variables = null, CancellationToken cancellationToken = default);
        Task<Weather> GetWeatherAsync(CancellationToken cancellationToken = default);
        Task<GarageDoor> GetGarageDoor(int Id, CancellationToken cancellationToken = default);
        Task<GarageDoor> ToggleGarageDoor(int Id, CancellationToken cancellationToken = default);
    }
}
