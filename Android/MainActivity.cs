using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using STLBrewReview.Mobile;


namespace STLBrewReviewMobile.Android
{
	[Activity (Label = "STLBrewReviewMobile.Android.Android", MainLauncher = true, ScreenOrientation = global::Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);
			Xamarin.FormsMaps.Init (this, bundle);

			SetPage (App.GetMainPage ());
		}
	}
}

