using System;
using IdentityModel.OidcClient;
using UIKit;
using InFurSec.FlatApp.Shared;
using Newtonsoft.Json.Linq;

namespace InFurSec.FlatApp.iOS
{
    public partial class ViewController : UIViewController
    {
        public ApiClient _apiClient;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            _apiClient = new ApiClient(new SFAuthenticationSessionBrowser());
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            garageDoorButton.TouchUpInside += (object sender, EventArgs e) => {
                // Trigger the garage door


                // Fetch the status of the door


                garageDoorStatusLabel.Text = "Something?";
            };

            var weatherResult = _apiClient.RawQueryAsync(@"query{weather{temperature,temperatureWithWindChill,humidity,windSpeedAverage,windSpeedGust,windDirection,rainfall}}").GetAwaiter().GetResult();

            var weatherResultLinq = JObject.Parse(weatherResult);

            var temperature = (double)weatherResultLinq["data"]["weather"]["temperature"];
            var temperatureWithWindChill = (double)weatherResultLinq["data"]["weather"]["temperatureWithWindChill"];
            var humidity = (int)weatherResultLinq["data"]["weather"]["humidity"];
            var windSpeedAverage = (int)weatherResultLinq["data"]["weather"]["windSpeedAverage"];
            var windSpeedGust = (int)weatherResultLinq["data"]["weather"]["windSpeedGust"];
            var windDirection = (int)weatherResultLinq["data"]["weather"]["windDirection"];
            var rainfall = (double)weatherResultLinq["data"]["weather"]["rainfall"];

            weatherDisplay.Text = $"Temperature = {temperature}ºC\n" +
                $"Temperature with Wind Chill = {temperatureWithWindChill}ºC" +
                $"Humidity = {humidity}%" +
                $"Wind Speed Avg = {windSpeedAverage}km/h" +
                $"Wind Speed Gust = {windSpeedGust}km/h" +
                $"Wind Direction = {windDirection}º" +
                $"Rainfall = {rainfall}mm";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
