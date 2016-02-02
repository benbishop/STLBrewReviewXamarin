using System;
using Xamarin.Forms;
using STLBrewReviewMobile.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(ImageCell), typeof(BrewReviewImageCellRenderer))]
namespace STLBrewReviewMobile.iOS
{
	public class BrewReviewImageCellRenderer:ImageCellRenderer
	{
		public BrewReviewImageCellRenderer ()
		{
		}

        public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
        {
            var view = base.GetCell (item, reusableCell, tv);
            view.Accessory = UIKit.UITableViewCellAccessory.DisclosureIndicator;
            return view;
        }

	}
}

