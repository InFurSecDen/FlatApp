using System;
using System.Threading.Tasks;
using System.Threading;
using System.IdentityModel.Tokens.Jwt;
namespace InFurSec.FlatApp.Core
{
    public class UserManager
    {
        private static UserManager __instance;

        private JwtSecurityToken _accessToken = null;
        private string _refreshToken = null;
        private string _allowedScopes = null;

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

            throw new NotImplementedException();
        }

        public async Task<bool> LoadContextAsync(string refreshToken, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }

        public async Task LogoutAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }

        public async Task<JwtSecurityToken> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }
    }
}
