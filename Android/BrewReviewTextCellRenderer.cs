using Xamarin.Forms.Platform.Android;
using STLBrewReviewMobile.Android;
using Xamarin.Forms;
using STLBrewReview.Mobile.Global;
using Android.App;
using Android.Widget;


[assembly: ExportRenderer (typeof(BrewReviewTextCell), typeof(BrewReviewTextCellRenderer))]
namespace STLBrewReviewMobile.Android
{
	public class BrewReviewTextCellRenderer:TextCellRenderer
	{
		public BrewReviewTextCellRenderer ()
		{
		}

		protected override global::Android.Views.View GetCellCore (Cell item, global::Android.Views.View convertView, global::Android.Views.ViewGroup parent, global::Android.Content.Context context)
		{
//			var view = convertView;


//			if (view == null) // no view to re-use, create new
			var view = (context as Activity).LayoutInflater.Inflate (Resource.Layout.TextCell, null);

			view.FindViewById<TextView> (Resource.Id.titleTextView).Text = (item as TextCell).Text;

			return view;
		}
	}
}

