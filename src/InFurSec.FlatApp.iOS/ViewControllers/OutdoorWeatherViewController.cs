using Foundation;
using InFurSec.FlatApp.Core;
using System;
using System.Net.Http;
using UIKit;

namespace InFurSec.FlatApp.iOS
{
    public partial class OutdoorWeatherViewController : UIViewController
    {
        public OutdoorWeatherViewController (IntPtr handle) : base (handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var user = UserManager.Instance;

            var accessToken = await user.GetAccessTokenAsync();

            if (accessToken == null || accessToken.ValidTo < DateTime.UtcNow)
            {
                TempWeatherDisplay.Text = "Not logged in.";
                return;
            }
             
            // To support TLS 1.2:
            var nsUrlSessionHandler = new NSUrlSessionHandler();

            IApiClient apiClient = new ApiClient(accessToken.RawData, nsUrlSessionHandler);

            var result = await apiClient.GetWeatherAsync();

            TempWeatherDisplay.Text = $"Temperature: {result.Temperature}℃\n" +
                $"Humidity: {result.Humidity}%\n" +
                $"Wind Speed: {result.WindSpeedAverage}km/h (gusts to {result.WindSpeedGust}km/h)\n" +
                $"Wind Direction: {result.WindDirection}º\n" +
                $"Rainfall: {result.Rainfall}mm";
        }
    }
}