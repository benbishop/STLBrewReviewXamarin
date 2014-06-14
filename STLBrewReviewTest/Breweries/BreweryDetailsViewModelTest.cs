using NUnit.Framework;
using System;
using STLBrewReview.Mobile.Breweries.Detail;
using Ploeh.AutoFixture;
using Should;
using STLBrewReview.Mobile.Breweries;
using System.ComponentModel;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class BreweryDetailsViewModelTest
	{

		Brewery TestBrewery;

		BreweryDetailsViewModel ViewModelUT;

		[Test]
		public void Verify_Props_Set ()
		{
			VerifyPropSet ("Title", "name");
			VerifyPropSet ("LogoURL", "image_url");
			VerifyPropSet ("Description", "description");
			VerifyPropSet ("WebsiteURL", "website_url");
			VerifyPropSet ("Email", "email");
			VerifyPropSet ("FacebookURL", "facebook_url");
			VerifyPropSet ("BreweryShortname", "short_name");
		}



		[Test]
		public void Verify_Address_Set ()
		{
			ViewModelUT.Address.ShouldEqual (TestBrewery.address + " Saint Louis ");
		}

		[Test]
		public void Verify_Phone_Number_Set ()
		{
			ViewModelUT.PhoneNumberURL.ShouldEqual ("tel:" + TestBrewery.phone);
		}

		[Test]
		public void Verify_Twitter_Set ()
		{
			ViewModelUT.TwitterURL.ShouldEqual ("http://www.twitter.com/" + TestBrewery.twitter_handle);
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

		protected void VerifyPropSet (string vmPropName, string breweryPropName)
		{
			Brewery brewery = Models.Brewery ();
			BreweryDetailsViewModel vmUT = new BreweryDetailsViewModel (brewery);
			vmUT.GetType ().GetProperty (vmPropName).GetValue (vmUT).ShouldEqual (brewery.GetType ().GetProperty (breweryPropName).GetValue (brewery));
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

