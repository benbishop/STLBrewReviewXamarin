using NUnit.Framework;
using System;
using STLBrewReview.Mobile.Breweries.List;
using FakeItEasy;
using STLBrewReview.Mobile.Global;
using STLBrewReview.Mobile.Beers;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class GetBeerServiceTest
	{
		GetBeersWebService ServiceUT;

		IWebClient FakeWebClient;

		[Test ()]
		public void Verify_URL_Opened ()
		{
			ServiceUT.Execute ("schlafly_bottle_works");
			A.CallTo (() => FakeWebClient.Get ("http://stlbrewreview.com/saint_louis/breweries/schlafly_bottle_works.json")).MustHaveHappened ();
		}

		[SetUp]
		public void Init ()
		{
			FakeWebClient = A.Fake<IWebClient> ();
			ServiceUT = new GetBeersWebService (FakeWebClient);
		}
	}
}

