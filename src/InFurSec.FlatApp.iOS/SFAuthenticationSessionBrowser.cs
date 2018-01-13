using Foundation;
using System.Threading.Tasks;
using IdentityModel.OidcClient.Browser;
using SafariServices;

namespace InFurSec.FlatApp.iOS
{
    public class SFAuthenticationSessionBrowser : IBrowser
    {
        SFAuthenticationSession _sf;

        public Task<BrowserResult> InvokeAsync(BrowserOptions options)
        {
            var wait = new TaskCompletionSource<BrowserResult>();

            _sf = new SFAuthenticationSession(
                new NSUrl(options.StartUrl),
                options.EndUrl,
                (callbackUrl, error) =>
                {
                    if (error != null)
                    {
                        var errorResult = new BrowserResult
                        {
                            ResultType = BrowserResultType.UserCancel,
                            Error = error.ToString()
                        };

                        wait.SetResult(errorResult);
                    }
                    else
                    {
                        var result = new BrowserResult
                        {
                            ResultType = BrowserResultType.Success,
                            Response = callbackUrl.AbsoluteString
                        };

                        wait.SetResult(result);
                    }
                });

            _sf.Start();
            return wait.Task;
        }
    }
}