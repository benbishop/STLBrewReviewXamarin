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
			if (URIImageSource != null) {
				URIImageSource.CachingEnabled = true;
			}
			base.OnBindingContextChanged ();

		}
	}
}

