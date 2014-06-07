using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class BreweryDetailsHeader:AbsoluteLayout
	{
		public BreweryDetailsHeader (string logoURL, string address)
		{
			BuildUI (logoURL, address);
		}

		protected async void BuildUI (string logoURL, string address)
		{
			var LogoSource = new UriImageSource () {
				Uri = new Uri (logoURL, UriKind.Absolute)
			};

			var breweryLocation = await GetGPSCoordinates (address);
			var mapStartLocation = new Position (breweryLocation.Latitude, breweryLocation.Longitude - .005);
			var map = new Map (new MapSpan (mapStartLocation, .01, .01)) {
				HeightRequest = 100,
				WidthRequest = this.Width,
				IsShowingUser = true,
				HasScrollEnabled = false,
				HasZoomEnabled = false

			};

			map.Pins.Add (new Pin () {
				Position = breweryLocation,
				Label = "Beer"

			});

			VerticalOptions = LayoutOptions.StartAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			MinimumHeightRequest = 100;
			HeightRequest = 100;

			Children.Add (map);
			Children.Add (
				
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
				}

			);
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

