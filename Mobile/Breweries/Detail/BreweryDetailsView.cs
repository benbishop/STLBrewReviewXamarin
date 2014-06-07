using System;
using STLBrewReview.Mobile.Global;
using Xamarin.Forms;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.ServiceModel.Channels;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class BreweryDetailsView:BaseView
	{
		protected readonly BreweryDetailsViewModel VM;

		public BreweryDetailsView (BreweryDetailsViewModel vm)
		{
			BindingContext = VM = vm;

			BuildUI ();
		}

		protected void BuildUI ()
		{


			var Heading = new BreweryDetailsHeader (VM.LogoURL, VM.Address);

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

