using IdentityModel.OidcClient.Browser;

namespace InFurSec.FlatApp.Core
{
    public class UserManagerOptions
    {
        public string ClientId { get; set; }
        public string CallbackUrl { get; set; }
        public IBrowser Browser { get; set; }
    }
}