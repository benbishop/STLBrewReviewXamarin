﻿using System;
using STLBrewReview.Mobile.Global;
using Xamarin.Forms;
using System.Collections.Generic;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class BreweryDetailsViewModel:BaseViewModel
	{
		public const string ACTIONPHONE = "phone";
		public const string ACTIONEMAIL = "email";
		public const string ACTIONWEBSITE = "website";
		public const string ACTIONMAP = "map";
		public const string ACTIONFACEBOOK = "facebook";
		public const string ACTIONTWITTER = "twitter";

		public BreweryDetailsViewModel (Brewery brewery)
		{
			this.Title = brewery.name;
			this.Description = brewery.description;
			this.LogoURL = brewery.image_url;
			this.Address = brewery.address;
			InitActions (brewery);
		}

		protected void InitActions (Brewery brewery)
		{
			Actions = new List<string> ();
			AddNotEmptyAction (ACTIONPHONE, brewery.phone);
			AddNotEmptyAction (ACTIONEMAIL, brewery.email);
			AddNotEmptyAction (ACTIONWEBSITE, brewery.website_url);
			AddNotEmptyAction (ACTIONMAP, brewery.address);
			AddNotEmptyAction (ACTIONFACEBOOK, brewery.facebook_url);
			AddNotEmptyAction (ACTIONTWITTER, brewery.twitter_handle);
		}

		protected void AddNotEmptyAction (string action, string breweryValue)
		{
			if (!String.IsNullOrEmpty (breweryValue)) {
				Actions.Add (action);
			}

		}

		public List<string> Actions {
			private set;
			get;
		}

		public string LogoURL {
			private set;
			get;
		}

		public string Address {
			private set;
			get;
		}



		public string Description {
			private set;
			get;
		}
	}
}

