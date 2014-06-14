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

		public override MonoTouch.UIKit.UITableViewCell GetCell (Cell item, MonoTouch.UIKit.UITableView tv)
		{
			var view = base.GetCell (item, tv);
			view.Accessory = MonoTouch.UIKit.UITableViewCellAccessory.DisclosureIndicator;
			return view;
		}
	}
}

