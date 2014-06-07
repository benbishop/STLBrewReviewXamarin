using System;
using STLBrewReview.Mobile.Global;
using Xamarin.Forms;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class BreweryDetailsViewModel:BaseViewModel
	{
		public BreweryDetailsViewModel (Brewery brewery)
		{
			this.Title = brewery.name;
			this.Description = brewery.description;
			this.LogoURL = brewery.image_url;
			this.Address = brewery.address;
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

