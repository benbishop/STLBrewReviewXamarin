using NUnit.Framework;
using System;
using Newtonsoft.Json;
using STLBrewReview.Mobile.Breweries;
using Should;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class BreweryModelTest
	{
		[Test ()]
		public void Verfity_JSON_Parsing ()
		{
			Brewery breweryUT = JsonConvert.DeserializeObject<Brewery> (JSON.Brewery);
			breweryUT.id.ShouldBeGreaterThan (0);
			breweryUT.address.ShouldNotBeNull ();
			breweryUT.created_at.Month.ShouldEqual (2);
			breweryUT.created_at.Year.ShouldEqual (2012);
			breweryUT.created_at.Day.ShouldEqual (25);
			breweryUT.description.ShouldNotBeNull ();
			breweryUT.email.ShouldNotBeNull ();
			breweryUT.twitter_handle.ShouldNotBeNull ();
			breweryUT.image_url.ShouldNotBeNull ();
			breweryUT.phone.ShouldNotBeNull ();
			breweryUT.rss_url.ShouldNotBeNull ();
			breweryUT.short_name.ShouldNotBeNull ();
			breweryUT.website_url.ShouldNotBeNull ();
		}
	}
}

