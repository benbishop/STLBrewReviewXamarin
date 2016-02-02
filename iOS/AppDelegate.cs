using System;
using System.Collections.Generic;
using System.Linq;

using STLBrewReview.Mobile;
using UIKit;
using Foundation;
using Xamarin.Forms;
using Xamarin;



namespace STLBrewReviewMobile.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			UINavigationBar.Appearance.SetTitleTextAttributes (new UITextAttributes () {
				TextColor = UIColor.White
			});

			UIApplication.SharedApplication.SetStatusBarStyle (UIStatusBarStyle.LightContent, false);
			Forms.Init ();
			FormsMaps.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			window.RootViewController = App.GetMainPage ().CreateViewController ();
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

