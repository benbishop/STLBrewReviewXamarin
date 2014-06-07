using System;
using STLBrewReview.Mobile.Breweries;
using Ploeh.AutoFixture;

namespace STLBrewReviewTest
{
	public static class Models
	{
		private static Fixture Fixture = new Fixture ();

		public static Brewery Brewery (string name = null)
		{
			var brewery = Fixture.Create<Brewery> ();
			if (name != null) {
				brewery.name = name;
			}
			return brewery;
		}
	}
}

