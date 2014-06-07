using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class ActionsMenu:StackLayout
	{
		public ActionsMenu (List<string> actions)
		{
			Orientation = StackOrientation.Horizontal;
			Padding = 10;
			Spacing = 10;
			VerticalOptions = LayoutOptions.End;
			HorizontalOptions = LayoutOptions.CenterAndExpand;

			foreach (var action in actions) {
				Children.Add (
					new Image () {
						Source = new FileImageSource () {
							File = action + ".png"
						}
					});
			}

		}
	}
}

