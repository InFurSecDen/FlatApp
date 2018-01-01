// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace InFurSec.FlatApp.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton garageDoorButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel garageDoorStatusLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel weatherDisplay { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (garageDoorButton != null) {
                garageDoorButton.Dispose ();
                garageDoorButton = null;
            }

            if (garageDoorStatusLabel != null) {
                garageDoorStatusLabel.Dispose ();
                garageDoorStatusLabel = null;
            }

            if (weatherDisplay != null) {
                weatherDisplay.Dispose ();
                weatherDisplay = null;
            }
        }
    }
}