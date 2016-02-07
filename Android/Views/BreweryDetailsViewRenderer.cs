using System;
using Xamarin.Forms;
using STLBrewReview.Mobile.Breweries.Detail;
using STLBrewReviewMobile.Android;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Android.Content;
using Android.Content.PM;


[assembly:ExportRenderer(typeof(BreweryDetailsView), typeof(BreweryDetailsViewRenderer))]
namespace STLBrewReviewMobile.Android
{
    public class BreweryDetailsViewRenderer:PageRenderer
    {
        public BreweryDetailsViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            BreweryDetailsView view = (BreweryDetailsView)e.NewElement;
            view.MakePhoneCall += CreatePhoneCallIntent;
            view.OpenEmail += CreateEmailIntent;
            view.LaunchMapApp += LaunchMapApp;

            base.OnElementChanged(e);
        }



        void CreatePhoneCallIntent(string phoneNumber)
        {
            var uri = global::Android.Net.Uri.Parse(phoneNumber);
            var intent = new Intent(Intent.ActionView, uri); 
            this.Context.StartActivity(intent);
        }

        void CreateEmailIntent(string email)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.PutExtra(Intent.ExtraEmail, new string[]{ email });
            intent.SetType("message/rfc822");
            this.Context.StartActivity(intent);
        }

        void LaunchMapApp(string address)
        {
            Intent intent = new Intent(Intent.ActionView, global::Android.Net.Uri.Parse("google.navigation:q=" + address));
            this.Context.StartActivity(intent);
        }
    }
}

