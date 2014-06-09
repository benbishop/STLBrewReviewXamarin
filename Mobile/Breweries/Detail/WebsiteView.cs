using System;
using STLBrewReview.Mobile.Global;
using Xamarin.Forms;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class WebsiteView : BaseView
	{
		public WebsiteView (string site, string title)
		{
			this.Title = title;
			var webView = new WebView ();
			webView.Source = new UrlWebViewSource {
				Url = site
			};
			Content = webView;
		}
	}
}

