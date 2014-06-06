using NUnit.Framework;
using System;
using STLBrewReview.Mobile.Beers;
using Newtonsoft.Json;
using Should;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class BeerModelTest
	{
		[Test ()]
		public void Verfity_JSON_Parsing ()
		{
			Beer beerUT = JsonConvert.DeserializeObject<Beer> (JSON.Beer);
			beerUT.abv.ShouldEqual (5);
			beerUT.appearance.ShouldNotBeNull ();
			beerUT.brewery_id.ShouldEqual (69);
			beerUT.created_at.Day.ShouldEqual (25);
			beerUT.created_at.Year.ShouldEqual (2012);
			beerUT.created_at.Month.ShouldEqual (2);
			beerUT.description.ShouldNotBeNull ();
			beerUT.hops.ShouldNotBeNull ();
			beerUT.ibu.ShouldEqual (30);
			beerUT.id.ShouldEqual (179);
			beerUT.image_url.ShouldNotBeNull ();
			beerUT.in_production.ShouldBeTrue ();
			beerUT.malts.ShouldNotBeNull ();
			beerUT.name.ShouldNotBeNull ();
			beerUT.og.ShouldEqual (12.3m);
			beerUT.process.ShouldNotBeNull ();
			beerUT.short_name.ShouldNotBeNull ();
			beerUT.site_link_url.ShouldNotBeNull ();
			beerUT.srm.ShouldEqual (4.5m);

			beerUT.yeast.ShouldNotBeNull ();
		}
	}
}

