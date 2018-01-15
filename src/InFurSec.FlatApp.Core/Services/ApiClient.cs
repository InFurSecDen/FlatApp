using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace InFurSec.FlatApp.Core
{
    public class ApiClient : IApiClient
    {
        private readonly string _accessToken;
        private readonly GraphQLClient _graphQlClient;

        public ApiClient(string accessToken, HttpMessageHandler httpMessageHandler = null)
        {
            _accessToken = accessToken;

            // Some HttpClient implementations do not support TLS 1.2, so here we are :|
            var graphQLClientOptions = new GraphQLClientOptions();
            if (httpMessageHandler != null) graphQLClientOptions.HttpMessageHandler = httpMessageHandler;

            _graphQlClient = new GraphQLClient(@"https://shittyapi.infursec.furry.nz:7448/graphql", graphQLClientOptions);
        }

        public Task<GarageDoor> GetGarageDoor(int Id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public async Task<Weather> GetWeatherAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = @"query{weather{temperature,temperatureWithWindChill,humidity,windSpeedAverage,windSpeedGust,windDirection,rainfall}}";

            var json = await RawQueryAsync(query, null, cancellationToken);

            JObject resultObject = JObject.Parse(json);

            var result = resultObject["weather"].ToObject<Weather>();

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

            return ((JObject)JToken.FromObject(response.Data)).ToString(); // TODO: Need to map this to a JSON string somehow, I don't think ToString works here
        }

        public Task<GarageDoor> ToggleGarageDoor(int Id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
