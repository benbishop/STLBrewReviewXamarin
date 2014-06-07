using System;

using Xamarin.Forms;
using STLBrewReview.Mobile.Breweries.List;
using STLBrewReview.Mobile.Config;

namespace STLBrewReview.Mobile
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			BrewReviewContext.Init ();



			var navigationPage = new NavigationPage (new BreweriesListView (new BreweriesListViewModel ())) {
				Tint = Color.Black
			};


			return navigationPage;
		}
	}
}

