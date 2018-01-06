using System;
namespace InFurSec.FlatApp.Shared
{
    public class UserContext
    {
        private int? _userId;
        private string _identityToken;
        private string _refreshToken;
        private string _accessToken;
        private DateTimeOffset? _identityTokenExpiry;
        private DateTimeOffset? _refreshTokenExpiry;
        private DateTimeOffset? _accessTokenExpiry;

        public int? UserId { get => _userId; }

        public string IdentityToken 
        { 
            get
            {
                if (_identityTokenExpiry.HasValue && DateTimeOffset.Now > _identityTokenExpiry.Value)
                {
                    _identityToken = null;
                }
                return _identityToken;
            }
        }
        public string RefreshToken
        {
            get
            {
                if (_refreshTokenExpiry.HasValue && DateTimeOffset.Now > _refreshTokenExpiry)
                {
                    _refreshToken = null;
                }
                return _refreshToken;
            }
        }
        public string AccessToken
        {
            get
            {
                if (_accessTokenExpiry.HasValue && DateTimeOffset.Now > _accessTokenExpiry)
                {
                    _accessToken = null;
                }
                return _accessToken;
            }
        }

        public bool IsAuthenticated() => RefreshToken != null && AccessToken != null;

        public void Authenticate(string identityToken, DateTimeOffset identityTokenExpiry, string refreshToken, DateTimeOffset refreshTokenExpiry, string accessToken, DateTimeOffset accessTokenExpiry)
        {
            _identityToken = identityToken;
            _identityTokenExpiry = identityTokenExpiry;
            _refreshToken = refreshToken;
            _refreshTokenExpiry = refreshTokenExpiry;
            _accessToken = accessToken;
            _accessTokenExpiry = accessTokenExpiry;
        }

        public void UpdateToken(string accessToken, DateTimeOffset accessTokenExpiry)
        {
            _accessToken = accessToken;
            _accessTokenExpiry = accessTokenExpiry;
        }

        public void LogOutUser()
        {
            _userId = null;

            _identityToken = null;
            _identityTokenExpiry = null;
            _refreshToken = null;
            _refreshTokenExpiry = null;
            _accessToken = null;
            _accessTokenExpiry = null;
        }
    }
}
