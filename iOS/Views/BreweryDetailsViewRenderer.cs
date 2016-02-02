using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using STLBrewReview.Mobile.Breweries.Detail;
using STLBrewReviewMobile.iOS;
using UIKit;
using Foundation;
using MessageUI;

[assembly:ExportRenderer (typeof(BreweryDetailsView), typeof(BreweryDetailsViewRenderer))]
namespace STLBrewReviewMobile.iOS
{
	public class BreweryDetailsViewRenderer:PageRenderer
	{
		public BreweryDetailsViewRenderer ()
		{
		}
            

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            BreweryDetailsView view = (BreweryDetailsView)e.NewElement;
            view.MakePhoneCall += TryService;
            view.OpenEmail += OpenEmail;
            view.LaunchMapApp += (string address) => TryService ("http://maps.apple.com/?daddr=" + address);


            base.OnElementChanged(e);
        }
//
//		protected override void OnModelSet (VisualElement model)
//		{
//			BreweryDetailsView view = (BreweryDetailsView)model;
//			view.MakePhoneCall += TryService;
//			view.OpenEmail += OpenEmail;
//			view.LaunchMapApp += (string address) => TryService ("http://maps.apple.com/?daddr=" + address);
//
//			base.OnModelSet (model);
//		}

		void OpenEmail (string email)
		{
			MFMailComposeViewController emailController;
			emailController = new MFMailComposeViewController ();
			emailController.SetToRecipients (new string[]{ email });
            var uITextAttributes = new UIStringAttributes();
            uITextAttributes.ForegroundColor = UIColor.Black;
            emailController.NavigationBar.TitleTextAttributes = uITextAttributes;
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

