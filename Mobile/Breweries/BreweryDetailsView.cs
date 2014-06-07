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

		protected void BuildUI (Brewery brewery)
		{


			var Heading = new BreweryDetailsHeader (brewery.image_url, brewery.address);

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

			Content = new StackLayout {

				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = { 
					Heading
					, 
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


	}
}

