using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using Newtonsoft.Json;

namespace InFurSec.FlatApp.Core
{
    public class ApiClient : IApiClient
    {
        private readonly string _accessToken;
        private readonly GraphQLClient _graphQlClient;

        public ApiClient(string accessToken)
        {
            _accessToken = accessToken;
            _graphQlClient = new GraphQLClient(@"https://shittyapi.infursec.furry.nz/graphql");
        }

        public Task<GarageDoor> GetGarageDoor(int Id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public async Task<Weather> GetWeatherAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = @"query{weather{temperature,temperatureWithWindChill,humidity,windSpeedAverage,windSpeedGust,windDirection,rainfall}}";

            var json = await RawQueryAsync(query, null, cancellationToken);

            var result = JsonConvert.DeserializeObject<Weather>(json);

            return result;
        }

        public async Task<string> RawQueryAsync(string query, string variables = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var request = new GraphQLRequest
            {
                Query = query,
                Variables = variables,
            };

            _graphQlClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _graphQlClient.PostAsync(request);

            return response.Data.ToString();
        }

        public Task<GarageDoor> ToggleGarageDoor(int Id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
