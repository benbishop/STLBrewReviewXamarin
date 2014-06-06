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
			Beer beerUT = JsonConvert.DeserializeObject<Beer> ("{\"abv\":\"5.0\",\"appearance\":\"Golden, bright\",\"brewery_id\":69,\"created_at\":\"2012-02-25T22:22:56Z\",\"description\":\"Our Pilsner is golden and crystal clear. The hops add a pleasant bitterness and a lemony, peppery taste.\",\"hops\":\"Marynka, Lublin (PL)\",\"ibu\":30,\"id\":179,\"image_url\":\"http://www.schlafly.com/uploads/2010/11/29/pilsnerlnd.png\",\"in_production\":true,\"malts\":\"2-row malted barley, Caravienne, Carapils malt\",\"name\":\"Pilsner\",\"og\":\"12.3\",\"process\":\"Traditional Lager\",\"short_name\":\"schlafly_pilsner\",\"site_link_url\":\"http://www.schlafly.com/beers/styles/pilsner/\",\"srm\":\"4.5\",\"updated_at\":\"2012-02-25T22:22:56Z\",\"yeast\":\"German Lager\"}");
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

