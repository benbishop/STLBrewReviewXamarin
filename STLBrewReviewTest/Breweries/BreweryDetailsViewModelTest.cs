using NUnit.Framework;
using System;
using STLBrewReview.Mobile.Breweries;
using Ploeh.AutoFixture;
using Should;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class BreweryDetailsViewModelTest
	{

		Brewery TestBrewery;

		BreweryDetailsViewModel ViewModelUT;

		[Test]
		public void Verify_Title_Set ()
		{
			ViewModelUT.Title.ShouldEqual (TestBrewery.name);
		}

		[SetUp]
		public void Init ()
		{

			TestBrewery = Models.Brewery ();
			ViewModelUT = new BreweryDetailsViewModel (TestBrewery);
		}
	}
}

