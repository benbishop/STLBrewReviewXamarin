using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using STLBrewReviewMobile.iOS;
using STLBrewReview.Mobile.Global;
using STLBrewReviewMobile.iOS.Views;
using UIKit;

[assembly: ExportRenderer (typeof(BrewReviewTextCell), typeof(BrewReviewTextCellRenderer))]
namespace STLBrewReviewMobile.iOS.Views
{

	public class BrewReviewTextCellRenderer:TextCellRenderer
	{
		public BrewReviewTextCellRenderer ()
		{
		}

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            UITableViewCell cell = base.GetCell (item, reusableCell, tv);
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            return cell;
        }
	}
}

