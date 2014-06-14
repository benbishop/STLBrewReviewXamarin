using NUnit.Framework;
using System;
using STLBrewReview.Mobile.Breweries.List;
using FakeItEasy;
using STLBrewReview.Mobile.Global;
using STLBrewReview.Mobile.Beers;
using Should;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class GetBeerServiceTest
	{
		GetBeersWebService ServiceUT;

		IWebClient FakeWebClient;

		[Test]
		public void Verify_URL_Opened ()
		{
			ServiceUT.Execute ("schlafly_bottle_works");
			A.CallTo (() => FakeWebClient.Get ("http://stlbrewreview.com/saint_louis/breweries/schlafly_bottle_works.json")).MustHaveHappened ();
		}

		[Test]
		public void Verify_Parse_Result ()
		{
			bool resultRaised = false;
			ServiceUT.Execute ("schlafly_bottle_works");
			ServiceUT.BeersReceived += (object sender, EventArgs e) => {
				resultRaised = true;
				(e as BeersReceivedEventArgs).Beers.Count.ShouldEqual (2);
			};
			FakeWebClient.ResponseReceived += Raise.With (new WebClientResultEventArgs (true, JSON.BreweryWithBeers (new string[] {
				JSON.Beer,
				JSON.Beer
			})) as EventArgs).Now;

			resultRaised.ShouldBeTrue ();
		}

		[SetUp]
		public void Init ()
		{
			FakeWebClient = A.Fake<IWebClient> ();
			ServiceUT = new GetBeersWebService (FakeWebClient);
		}
	}
}

