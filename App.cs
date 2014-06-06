﻿using System;

using Xamarin.Forms;
using STLBrewReview.Mobile.Breweries;
using STLBrewReview.Mobile.Config;

namespace STLBrewReview.Mobile
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			BrewReviewContext.Init ();



			var navigationPage = new NavigationPage (new BreweriesListView ()) {
				Tint = Color.Black
			};


			return navigationPage;
		}
	}
}

