using System;
using MonkeyArms;
using STLBrewReview.Mobile.Breweries;
using STLBrewReview.Mobile.Global;

namespace STLBrewReview.Mobile.Config
{
	public static class BrewReviewContext
	{
		public static void Init ()
		{
			DI.MapClassToInterface<SimpleWebClient, IWebClient> ();
			DI.MapClassToInterface<GetBreweriesWebService, IGetBreweriesWebService> ();

			DI.MapCommandToInvoker<GetBreweriesCommand, RequestBreweriesInvoker> ();


		}
	}
}

