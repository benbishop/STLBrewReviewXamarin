using System;
using Xamarin.Forms;

namespace STLBrewReview.Mobile.Beers
{
	public class BeerCell:ImageCell
	{
		public BeerCell ()
		{
			TextColor = Color.Black;

		}

		protected override void OnBindingContextChanged ()
		{

			var URIImageSource = (UriImageSource)ImageSource;
			URIImageSource.CachingEnabled = true;
			base.OnBindingContextChanged ();

		}
	}
}

