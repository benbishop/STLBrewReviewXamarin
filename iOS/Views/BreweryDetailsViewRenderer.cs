using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using STLBrewReview.Mobile.Breweries.Detail;
using STLBrewReviewMobile.iOS;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.MessageUI;

[assembly:ExportRenderer (typeof(BreweryDetailsView), typeof(BreweryDetailsViewRenderer))]
namespace STLBrewReviewMobile.iOS
{
	public class BreweryDetailsViewRenderer:PageRenderer
	{
		public BreweryDetailsViewRenderer ()
		{
		}



		protected override void OnModelSet (VisualElement model)
		{
			BreweryDetailsView view = (BreweryDetailsView)model;
			view.MakePhoneCall += TryService;
			view.OpenEmail += OpenEmail;
			view.LaunchMapApp += (string address) => TryService ("http://maps.apple.com/?daddr=" + address);
			base.OnModelSet (model);
		}

		void OpenEmail (string email)
		{
			MFMailComposeViewController emailController;
			emailController = new MFMailComposeViewController ();
			emailController.SetToRecipients (new string[]{ email });
			emailController.NavigationBar.SetTitleTextAttributes (new UITextAttributes (){ TextColor = UIColor.Black });
			emailController.Finished += (object sender, MFComposeResultEventArgs e) => e.Controller.DismissViewController (true, null);
			PresentViewController (emailController, true, null);
		}

		protected void TryService (string nsURL)
		{
			try {
				UIApplication.SharedApplication.OpenUrl (new NSUrl (nsURL));
			} catch {
				UIAlertView view = new UIAlertView ("Service Not Available", "You're requested service is not available on this device.", null, "Ok", null);
				view.Show ();
			}
		}
	}
}

