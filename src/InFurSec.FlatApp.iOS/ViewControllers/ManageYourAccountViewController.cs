using Foundation;
using InFurSec.FlatApp.Core;
using System;
using UIKit;

namespace InFurSec.FlatApp.iOS
{
    public partial class ManageYourAccountViewController : UIViewController
    {
        public ManageYourAccountViewController (IntPtr handle) : base (handle)
        {
        }

        async partial void TempLogInButton_TouchUpInsideAsync(UIButton sender)
        {
            var user = UserManager.Instance;

            var loginSucceeded = await user.LoginAsync();
        }
    }
}