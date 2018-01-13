using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace InFurSec.FlatApp.Core
{
    public class OpenIDConnectAuthClient : IAuthClient
    {
        public OpenIDConnectAuthClient()
        {
        }

        public Task<bool> HasTokenExpiredAsync(string jwt, CancellationToken cancellationToken = default(CancellationToken))
        {
            // https://gist.github.com/ahelland/6d6aa9fbb1cd090cebee53f62adff2d7#file-jwtcracker-cs
            var jwtHandler = new JwtSecurityTokenHandler();

            if (!jwtHandler.CanReadToken(jwt)) throw new ArgumentException("This does not seem to be a valid JWT.", nameof(jwt));

            var token = jwtHandler.ReadJwtToken(jwt);

            return Task.FromResult(token.ValidTo < DateTime.Now);
        }
    }
}
