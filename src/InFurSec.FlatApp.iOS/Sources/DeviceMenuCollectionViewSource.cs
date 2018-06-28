using System;

using UIKit;
using Foundation;
using CoreGraphics;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace InFurSec.FlatApp.iOS
{
	public class DeviceMenuCollectionViewSource : UICollectionViewSource
    {
        private List<string> _menuItems;

        public DeviceMenuCollectionViewSource(List<string> menuItems)
        {
            _menuItems = menuItems;
        }

		public override nint NumberOfSections(UICollectionView collectionView)
		{
            return 1;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
            return _menuItems.Count; 
		}

		public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
		{
            return true;
		}

        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (DeviceMenuCollectionViewCell)collectionView.CellForItem(indexPath);
            cell.SetTransparency(0.325f);
        }

        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (DeviceMenuCollectionViewCell)collectionView.CellForItem(indexPath);
            cell.SetTransparency(0.75f);
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (DeviceMenuCollectionViewCell)collectionView.DequeueReusableCell(DeviceMenuCollectionViewCell.Key, indexPath);
            cell.UpdateCellTitle(_menuItems[indexPath.Row]);

            return cell;
        }
	}
}
