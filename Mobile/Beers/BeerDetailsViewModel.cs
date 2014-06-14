using System;
using STLBrewReview.Mobile.Global;
using System.Net.Http.Headers;
using System.ServiceModel.Description;
using System.Collections.Generic;

namespace STLBrewReview.Mobile.Beers
{
	public class BeerDetailsViewModel:BaseViewModel
	{
	
		public BeerDetailsViewModel (Beer beer)
		{
			Title = beer.name;
			LogoURL = beer.image_url;
			Description = beer.description;

			Attributes = new List<string> ();
			
			AddIfNotEmpty (Attributes, "IBU", beer.ibu);
			AddIfNotEmpty (Attributes, "SRM", beer.srm);
			AddIfNotEmpty (Attributes, "ABV", beer.abv);
			AddIfNotEmpty (Attributes, "OG", beer.og);

			Ingredients = new List<string> ();
			AddIfNotEmpty (Ingredients, "Appearance", beer.appearance);
			AddIfNotEmpty (Ingredients, "Yeast", beer.yeast);
			AddIfNotEmpty (Ingredients, "Malts", beer.malts);
			AddIfNotEmpty (Ingredients, "Hops", beer.hops);
			AddIfNotEmpty (Ingredients, "Process", beer.process);
		}

		protected void AddIfNotEmpty (List<String> list, string label, object value)
		{
			if (value != null && value.ToString () != "0") {
				list.Add (label + ": " + value.ToString ());
			}
		}

		public List<string> Attributes {
			private set;
			get;
		}

		public List<string> Ingredients {
			private set;
			get;
		}

		public string LogoURL {
			private set;
			get;
		}

		public string Description {
			get;
			private set;
		}
	}
}

