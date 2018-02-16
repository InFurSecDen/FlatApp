using System;

using Foundation;
using UIKit;

namespace InFurSec.FlatApp.iOS
{
    public partial class EventCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("EventCollectionViewCell");
        public static readonly UINib Nib;

        static EventCollectionViewCell()
        {
            Nib = UINib.FromName("EventCollectionViewCell", NSBundle.MainBundle);
        }

        protected EventCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }


    }
}
