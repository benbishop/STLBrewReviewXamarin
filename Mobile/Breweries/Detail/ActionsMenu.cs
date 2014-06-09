using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class ActionsMenu:StackLayout
	{
		public Action<string> ActionTapped = delegate {
		};

		public ActionsMenu (List<string> actions)
		{


			Orientation = StackOrientation.Horizontal;
			Padding = 10;
			Spacing = 10;
			VerticalOptions = LayoutOptions.End;
			HorizontalOptions = LayoutOptions.CenterAndExpand;

			foreach (var action in actions) {
				var button = new Image () {
					Source = new FileImageSource () {
						File = action + ".png"
					}
				};
				button.GestureRecognizers.Add (new TapGestureRecognizer ((view, args) => {
					ActionTapped (action);
				}));

				Children.Add (button);
			}

		}
	}
}

