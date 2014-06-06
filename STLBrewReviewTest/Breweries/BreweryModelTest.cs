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
			Brewery breweryUT = JsonConvert.DeserializeObject<Brewery> ("{\n    \"address\": \"The Saint Louis Brewery, Inc. 2100 Locust Street, St. Louis, MO 63103\",\n    \"created_at\": \"2012-02-25T22:22:56Z\",\n    \"description\": \"Having been around Saint Louis for 20 plus years, it would be easy to label Schlafly as the old fogey. Schlafly is boldly proving that sentiment wrong with its Tap Room and Bottleworks breweries that are turning out 60 plus beers a year. These Schlafly venues also feature live music, good food, and numerous events throughout the year.\",\n    \"email\": \"questions@schlafly.com\",\n    \"facebook_url\": \"http://www.facebook.com/schlafly.beer.fans\",\n    \"id\": 69,\n    \"image_left\": 0,\n    \"image_top\": 0,\n    \"image_url\": \"http://www.stlouisearthday.org/wp-content/sled-uploads/schlafly_200px.png\",\n    \"name\": \"Schlafly\",\n    \"phone\": \" 314-241-BEER\",\n    \"phone_number\": null,\n    \"rss_url\": \"http://www.schlafly.com/community/blog/rss\",\n    \"short_name\": \"schlafly_bottle_works\",\n    \"twitter_handle\": \"schlafly\",\n    \"updated_at\": \"2012-02-25T22:22:56Z\",\n    \"website_url\": \"http://www.schlafly.com/\"\n}");
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

