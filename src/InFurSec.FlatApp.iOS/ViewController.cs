using System;

using UIKit;

namespace InFurSec.FlatApp.iOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
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
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
