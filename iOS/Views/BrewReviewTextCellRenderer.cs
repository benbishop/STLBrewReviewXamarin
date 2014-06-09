using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using STLBrewReviewMobile.iOS;
using STLBrewReview.Mobile.Global;
using STLBrewReviewMobile.iOS.Views;

[assembly: ExportRenderer (typeof(BrewReviewTextCell), typeof(BrewReviewTextCellRenderer))]
namespace STLBrewReviewMobile.iOS.Views
{

	public class BrewReviewTextCellRenderer:TextCellRenderer
	{
		public BrewReviewTextCellRenderer ()
		{
		}

		public override UITableViewCell GetCell (Cell item, UITableView tv)
		{
			UITableViewCell cell = base.GetCell (item, tv);
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}
	}
}

