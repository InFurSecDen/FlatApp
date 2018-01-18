using Foundation;
using System;
using UIKit;
using InFurSec.FlatApp.Core;
using System.Threading.Tasks;
using System.Net.Http;

namespace InFurSec.FlatApp.iOS
{
    public partial class WeatherTestViewController : UIViewController
    {
        public WeatherTestViewController (IntPtr handle) : base (handle)
        {
        }

        async partial void FetchWeatherButton_TouchUpInside(UIButton sender)
        {
            var user = UserManager.Instance;

            var accessToken = await user.GetAccessTokenAsync();

            // To support TLS 1.2:
            var nsUrlSessionHandler = new NSUrlSessionHandler();

            IApiClient apiClient = new ApiClient(accessToken.RawData, nsUrlSessionHandler);

            var result = await apiClient.GetWeatherAsync();

            WeatherDisplay.Text = result.Temperature + "℃";
        }

        async partial void LoginButton_TouchUpInside(UIButton sender)
        {
            var user = UserManager.Instance;

            var browser = new SFAuthenticationSessionBrowser();

            var loginSucceeded = await user.LoginAsync();
        }
    }
}