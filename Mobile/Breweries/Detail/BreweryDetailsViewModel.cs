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
			this.LogoURI = brewery.image_url;
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

		private string logoURI;
		public static string LogoURIPropName = "LogoURI";

		public string LogoURI {
			get { return logoURI; }
			set {
				logoURI = value;
				OnPropertyChanged (LogoURIPropName);
			}
		}

		public string Description {
			private set;
			get;
		}
	}
}

