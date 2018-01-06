using System;
using IdentityModel.OidcClient.Browser;
using System.Threading;
using GraphQL.Client;
using IdentityModel.OidcClient;
using System.Threading.Tasks;
using GraphQL.Common.Request;
using System.Net.Http.Headers;

namespace InFurSec.FlatApp.iOS
{
    public class ApiClient
    {
        private const string API_SCOPES = "openid profile email offline_access"; // Make scopes for "update last time at flat", etc

        private readonly OidcClient _oidcClient;
        private readonly GraphQLClient _graphqlClient;

        private string _refreshToken;
        private string _accessToken;
        private DateTimeOffset? _accessTokenExpiry;

        public ApiClient(IBrowser authenticationBrowser)
        {
            var oidcClientOptions = new OidcClientOptions
            {
                Authority = Settings.AuthServerEndpoint,
                ClientId = Settings.ApiClientId,
                Scope = API_SCOPES, 
                ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect,

                RedirectUri = "InFurSec://logincallback",

                Browser = authenticationBrowser,
            };

            _oidcClient = new OidcClient(oidcClientOptions);
            _graphqlClient = new GraphQLClient(Settings.ApiServerEndpoint);

        }

        public async Task<string> RawQueryAsync(string query, string variables = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var request = new GraphQLRequest
            {
                Query = query,
                Variables = variables,
            };

            _graphqlClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessTokenAsync(cancellationToken));
            var response = await _graphqlClient.PostAsync(request);

            return response.Data.ToString();
        }

        private async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (String.IsNullOrWhiteSpace(_refreshToken))
            {
                await LoginAsync(cancellationToken);
            }

            if (String.IsNullOrWhiteSpace(_accessToken) || DateTimeOffset.Now > _accessTokenExpiry)
            {
                await _oidcClient.RefreshTokenAsync(_refreshToken, cancellationToken);
            }

            return _accessToken;
        }

        private async Task<string> RefreshAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var refreshResult = await _oidcClient.RefreshTokenAsync(_refreshToken, cancellationToken);

            if (refreshResult.IsError)
            {
                return null;
            }

            _accessToken = refreshResult.AccessToken;
            _accessTokenExpiry = DateTimeOffset.FromUnixTimeMilliseconds(refreshResult.ExpiresIn);
            _refreshToken = refreshResult.RefreshToken;
            return refreshResult.AccessToken;
        }

        private async Task LoginAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var loginResult = await _oidcClient.LoginAsync(new LoginRequest());

            if (loginResult.IsError)
            {
                _accessToken = null;
                _accessTokenExpiry = null;
                _refreshToken = null;
            }

            _accessToken = loginResult.AccessToken;
            _accessTokenExpiry = loginResult.AccessTokenExpiration;
            _refreshToken = loginResult.RefreshToken;
        }
    }
}
