using System;

using Foundation;
using UIKit;
using CoreGraphics;

namespace InFurSec.FlatApp.iOS
{
    public partial class DeviceMenuCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("DeviceMenuCollectionViewCell");
        public static readonly UINib Nib;

        static DeviceMenuCollectionViewCell()
        {
            Nib = UINib.FromName("DeviceMenuCollectionViewCell", NSBundle.MainBundle);
        }

        protected DeviceMenuCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

		public void UpdateCellTitle(string mainTitle)
		{
			this.mainLabel.Text = mainTitle;
		}

		public void UpdateStatusLabel(string subLabel)
		{
            this.subLabel.Text = subLabel;
		}

        public void SetTransparency(float alpha)
        {
            // TODO: Check bounds

            this.Alpha = alpha;
        }
    }
}
