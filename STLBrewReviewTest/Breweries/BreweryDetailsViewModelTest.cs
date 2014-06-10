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
			ViewModelUT.Address.ShouldEqual (TestBrewery.address + " Saint Louis ");
		}

		[Test]
		public void Verify_Actions_Set_Based_On_Availability ()
		{
			VerifyActionInclusion (BreweryDetailsViewModel.ACTIONEMAIL, "email");
			VerifyActionInclusion (BreweryDetailsViewModel.ACTIONPHONE, "phone");
			VerifyActionInclusion (BreweryDetailsViewModel.ACTIONMAP, "address");
			VerifyActionInclusion (BreweryDetailsViewModel.ACTIONFACEBOOK, "facebook_url");
			VerifyActionInclusion (BreweryDetailsViewModel.ACTIONTWITTER, "twitter_handle");
			VerifyActionInclusion (BreweryDetailsViewModel.ACTIONWEBSITE, "website_url");
		}

		protected void VerifyActionInclusion (string action, string propName)
		{
			Brewery brewery = Models.Brewery ();
			BreweryDetailsViewModel vmUT = new BreweryDetailsViewModel (brewery);
			vmUT.Actions.ShouldContain (action);

			brewery.GetType ().GetProperty (propName).SetValue (brewery, null);
			vmUT = new BreweryDetailsViewModel (brewery);
			vmUT.Actions.ShouldNotContain (action);

			brewery.GetType ().GetProperty (propName).SetValue (brewery, "");
			vmUT = new BreweryDetailsViewModel (brewery);
			vmUT.Actions.ShouldNotContain (action);

		}



		[SetUp]
		public void Init ()
		{

			TestBrewery = Models.Brewery ();
			ViewModelUT = new BreweryDetailsViewModel (TestBrewery);
		}
	}
}

