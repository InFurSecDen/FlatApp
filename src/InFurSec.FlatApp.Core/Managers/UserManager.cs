using System;
using System.Threading.Tasks;
using System.Threading;
using System.IdentityModel.Tokens.Jwt;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using Microsoft.IdentityModel.Tokens;

namespace InFurSec.FlatApp.Core
{
    public class UserManager
    {
        private static UserManager __instance;

        private JwtSecurityToken _accessToken = null;
        private string _refreshToken = null;

        private string _clientId;
        private string _callbackUrl;
        private IBrowser _browser;

        private UserManager()
        {
        }

        public static UserManager Instance
        {
            get
            {
                if (__instance == null)
                {
                    __instance = new UserManager();
                }
                return __instance;
            }
        }

        public static void SetOptions(UserManagerOptions options)
        {
            Instance._clientId = options.ClientId;
            Instance._callbackUrl = options.CallbackUrl;
            Instance._browser = options.Browser;
        }

        public bool IsLoggedIn
        {
            get
            {
                return (String.IsNullOrWhiteSpace(_refreshToken));
            }
        }

        public bool IsVerifiedGuest
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsResident
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ScopeAccessLevel CanAccessGarageDoors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ScopeAccessLevel CanAccessWeatherStation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TimeSpan TimeSinceLastSeenInHouse
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset? SessionExpiry
        {
            get
            {
                if (_accessToken == null) return null;

                return _accessToken.ValidTo;
            }
        }

        public async Task<bool> LoginAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var oidcClient = GetOidcClient();
            var request = new LoginRequest();
            var result = await oidcClient.LoginAsync(request);

            if (result.IsError) return false; // TODO: Better error messages
                
            var jwtHandler = new JwtSecurityTokenHandler();
            if (!jwtHandler.CanReadToken(result.AccessToken)) throw new SecurityTokenValidationException("The server did not seem to issue a valid JWT.");
            var jwtToken = jwtHandler.ReadJwtToken(result.AccessToken);

            _refreshToken = result.RefreshToken;
            _accessToken = jwtToken;

            return true;
        }

        public Task<bool> LoadContextAsync(string refreshToken, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }

        public Task LogoutAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }

        public Task<JwtSecurityToken> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(_accessToken);
        }

        private OidcClient GetOidcClient()
        {
            var options = new OidcClientOptions
            {
                Authority = @"https://accounts.infursec.furry.nz",
                ClientId = _clientId,
                Scope = "openid profile resident garagedoor.read garagedoor.write weather.read offline_access",
                ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect,

                RedirectUri = _callbackUrl,
                PostLogoutRedirectUri = _callbackUrl,

                Browser = _browser,
            };

            return new OidcClient(options);
        }
    }
}
