using System;
using Xamarin.Forms;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class ActionsMenu:StackLayout
	{
		public ActionsMenu ()
		{
			Orientation = StackOrientation.Horizontal;
			Padding = 10;
			Spacing = 10;
			VerticalOptions = LayoutOptions.End;
			HorizontalOptions = LayoutOptions.CenterAndExpand;
			Children.Add (
				new Image () {
					Source = new FileImageSource () {
						File = "phone.png"
					}
				});
			Children.Add (
				new Image () {
					Source = new FileImageSource () {
						File = "email.png"
					}
				});
			Children.Add (
				new Image () {
					Source = new FileImageSource () {
						File = "map.png"
					}
				});
			Children.Add (
				new Image () {
					Source = new FileImageSource () {
						File = "website.png"
					}
				});
			Children.Add (
				new Image () {
					Source = new FileImageSource () {
						File = "facebook.png"
					}
				});
			Children.Add (
				new Image () {
					Source = new FileImageSource () {
						File = "twitter.png"
					}
				});
		}
	}
}

