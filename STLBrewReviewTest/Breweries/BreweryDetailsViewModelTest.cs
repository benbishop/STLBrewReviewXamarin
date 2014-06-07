using NUnit.Framework;
using System;
using STLBrewReview.Mobile.Breweries.Detail;
using Ploeh.AutoFixture;
using Should;
using STLBrewReview.Mobile.Breweries;

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

		[Test]
		public void Verify_LogoURL_Set ()
		{
			ViewModelUT.LogoURL.ShouldEqual (TestBrewery.image_url);
		}

		[Test]
		public void Verify_Address_Set ()
		{
			ViewModelUT.Address.ShouldEqual (TestBrewery.address);
		}

		[SetUp]
		public void Init ()
		{

			TestBrewery = Models.Brewery ();
			ViewModelUT = new BreweryDetailsViewModel (TestBrewery);
		}
	}
}

