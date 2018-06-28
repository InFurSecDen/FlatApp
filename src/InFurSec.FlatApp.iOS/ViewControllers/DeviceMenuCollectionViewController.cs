using System;

using UIKit;
using Foundation;
using System.Collections.Generic;

namespace InFurSec.FlatApp.iOS
{
    public partial class DeviceMenuCollectionViewController : UICollectionViewController
    {
        private List<string> _menuItems;

        public DeviceMenuCollectionViewController(IntPtr handle) : base(handle)
        {
            _menuItems = new List<string>
            {
                "Garage Door",
                "Lights",
                "Weather",
                "Internal Doors",
                "Speakers",
                "Heating",
                "Pool Table",
                "Alarm",
                "Door Bell",
                "Internet Connection",
                "Power Usage",
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            deviceMenuCollectionView.RegisterNibForCell(UINib.FromName("DeviceMenuCollectionViewCell", NSBundle.MainBundle), DeviceMenuCollectionViewCell.Key);
            deviceMenuCollectionView.Source = new DeviceMenuCollectionViewSource(_menuItems);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

