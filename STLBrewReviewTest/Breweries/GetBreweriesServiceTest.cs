using NUnit.Framework;
using System;
using STLBrewReview.Mobile.Breweries;
using FakeItEasy;
using STLBrewReview.Mobile.Global;
using System.Net;
using Should;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class GetBreweriesServiceTest
	{
		GetBreweriesWebService ServiceUT;

		IWebClient FakeWebClient;

		[Test]
		public void Verify_Gets_Correct_Url ()
		{
			ServiceUT.Execute ();
			A.CallTo (() => FakeWebClient.Get ("http://stlbrewreview.com/saint_louis/breweries.json")).MustHaveHappened ();
		}

		[Test]
		public void Verify_Parses_Result ()
		{
			bool resultRaised = false;

			ServiceUT.Execute ();
			ServiceUT.BreweriesReceived += (object sender, EventArgs e) => {
				resultRaised = true;
				(e as BreweriesReceivedEventArgs).Breweries.Count.ShouldEqual (2);
			};
			FakeWebClient.ResponseReceived += Raise.With (new WebClientResultEventArgs (true, "[" + JSON.Brewery + "," + JSON.Brewery + "]") as EventArgs).Now;

			resultRaised.ShouldBeTrue ();
		}

		[SetUp]
		public void InitSUT ()
		{
			ServiceUT = new GetBreweriesWebService ();
			FakeWebClient = A.Fake<IWebClient> ();
			ServiceUT.WebClient = FakeWebClient;
		}
	}
}

