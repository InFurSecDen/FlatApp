// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace InFurSec.FlatApp.iOS
{
    [Register ("WeatherTestViewController")]
    partial class WeatherTestViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton FetchWeatherButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WeatherDisplay { get; set; }

        [Action ("FetchWeatherButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FetchWeatherButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (FetchWeatherButton != null) {
                FetchWeatherButton.Dispose ();
                FetchWeatherButton = null;
            }

            if (WeatherDisplay != null) {
                WeatherDisplay.Dispose ();
                WeatherDisplay = null;
            }
        }
    }
}