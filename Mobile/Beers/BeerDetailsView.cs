using System;
using Xamarin.Forms;
using STLBrewReview.Mobile.Global;

namespace STLBrewReview.Mobile.Beers
{
	public class BeerDetailsView:BaseView
	{
		protected BeerDetailsViewModel VM;

		public BeerDetailsView (BeerDetailsViewModel vm)
		{
			this.BindingContext = VM = vm;
			BuildUI ();
		}

		void BuildUI ()
		{

			var LogoSource = new UriImageSource () {
				Uri = new Uri (VM.LogoURL, UriKind.Absolute)
			};
			var attributesBox = new Frame {
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White,
				Padding = new Thickness (15, 5, 10, 5),
				Content = new StackLayout {
					Orientation = StackOrientation.Horizontal,
					Spacing = 8

				}
			};


			foreach (var Attribute in VM.Attributes) {

				(attributesBox.Content as StackLayout).Children.Add (
					new Label () {
						Text = Attribute,
						TextColor = Color.Black,
						Font = Font.BoldSystemFontOfSize (10),
						BackgroundColor = Color.White
					}
				);
			}

			AbsoluteLayout header = new AbsoluteLayout {
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Red,
				Children = {
					new Image () {
						Aspect = Aspect.Fill,
						HeightRequest = 100,
						Source = new FileImageSource () {
							File = "beer_background.png"

						}
					},

				}
			};

			header.Children.Add (attributesBox, new Point (80, 40));
			header.Children.Add (new StackLayout {
				Padding = 10,

				Children = {
					new Image () {

						WidthRequest = 80,
						HeightRequest = 80,
						Source = LogoSource
					}
				}
			});

			this.Animate ("fadeIn", new Animation ((val) => {
				attributesBox.Opacity = val;
				attributesBox.Layout (new Rectangle (80 * val, attributesBox.Bounds.Y, attributesBox.Width, attributesBox.Height));
			}, 0, 1), 16, 1000, Easing.CubicOut);


			Content = new StackLayout {
				BackgroundColor = Color.White,
				Children = {
					header,
					new StackLayout {
						Padding = 10,
						VerticalOptions = LayoutOptions.Start,
						Children = {
							new Label {
								TextColor = Color.Black,
								Text = VM.Description,
								LineBreakMode = LineBreakMode.WordWrap,
								Font = Font.BoldSystemFontOfSize (14)
							}
						}
					},
					new ListView () {

						ItemsSource = VM.Ingredients
					}
				}
			};
		}
	}
}

