using System;
using STLBrewReview.Mobile.Global;
using Xamarin.Forms;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace STLBrewReview.Mobile.Breweries
{
	public class BreweryDetailsView:BaseView
	{
		BreweryDetailsViewModel VM;

		public BreweryDetailsView (Brewery brewery)
		{
			BindingContext = VM = new BreweryDetailsViewModel (brewery);

			BuildUI (brewery);
		}

		protected async void BuildUI (Brewery brewery)
		{
			var LogoSource = new UriImageSource () {
				Uri = new Uri (VM.LogoURI, UriKind.Absolute)
			};

			var breweryLocation = await GetGPSCoordinates (brewery.address);
			var mapStartLocation = new Position (breweryLocation.Latitude, breweryLocation.Longitude - .005);
			var map = new Map (new MapSpan (mapStartLocation, .01, .01)) {
				HeightRequest = 100,
				WidthRequest = this.Width,
				IsShowingUser = true,
				HasScrollEnabled = false,
				HasZoomEnabled = false

			};

			var Heading = new AbsoluteLayout () {
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 100,
				Children = {
					map,
					new StackLayout {
						Padding = 10,
						Children = {
							new Image () {
								VerticalOptions = LayoutOptions.Start,
								WidthRequest = 80,
								HeightRequest = 80,
								Source = LogoSource
							}
						}
					},

				}
			};




			var beersListView = new ListView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowHeight = 40
			};

			beersListView.ItemsSource = new List<string> (){ "Beers" };

			var contactListView = new ListView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowHeight = 40
			};

			contactListView.ItemsSource = new List<string> (){ "Website", "Map", "Phone", "Facebook", "Twitter" };





			map.Pins.Add (new Pin () {
				Position = breweryLocation,
				Label = brewery.name

			});

			Content = new StackLayout {

				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = { 
					Heading, 
					new StackLayout {
						Padding = 10,
						Children = {
							new Label {
								BackgroundColor = Color.White,
								VerticalOptions = LayoutOptions.StartAndExpand,
								Text = VM.Description,
								LineBreakMode = LineBreakMode.WordWrap,
								Font = Font.BoldSystemFontOfSize (10)
							}
						}
					},

					beersListView, 
					contactListView
				}

			};
		}

		protected async Task<Position> GetGPSCoordinates (string address)
		{
			return await Task.Run (async () => {
				var client = new HttpClient ();
				var response = await client.GetStringAsync ("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + " Saint Louis &key=AIzaSyDoyLKmSzfzfg1tQxO07282eLNAHuFSh5s");
				var results = JObject.Parse (response) ["results"] as JArray;
				var result = results [0];
				var geometry = result ["geometry"];
				var location = geometry ["location"];

				return new Position ((double)location ["lat"], (double)location ["lng"]);
			});
		}
	}
}

