using System;
using MonkeyArms;
using STLBrewReview.Mobile.Breweries.List;
using STLBrewReview.Mobile.Global;
using System.Dynamic;
using STLBrewReview.Mobile.Beers;

namespace STLBrewReview.Mobile.Config
{
	public static class BrewReviewContext
	{
		public static void Init ()
		{
			DI.MapClassToInterface<SimpleWebClient, IWebClient> ();
			DI.MapClassToInterface<GetBreweriesWebService, IGetBreweriesWebService> ();
			DI.MapClassToInterface<GetBeersWebService, IGetBeersWebService> ();

			DI.MapCommandToInvoker<GetBreweriesCommand, RequestBreweriesInvoker> ();
			DI.MapCommandToInvoker<GetBeersCommand, RequestBeersInvoker> ();


		}
	}
}

