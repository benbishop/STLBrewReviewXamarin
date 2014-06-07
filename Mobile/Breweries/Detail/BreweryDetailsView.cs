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




			var beersListView = new ListView {
				VerticalOptions = LayoutOptions.StartAndExpand,
				RowHeight = 40,

			};

			beersListView.ItemsSource = new List<string> (){ "Beers" };



			Content = new StackLayout {

				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Children = {

					new BreweryDetailsHeader (VM.LogoURL, VM.Address),

					new StackLayout {
						Padding = 10,
						VerticalOptions = LayoutOptions.Start,
						Children = {
							new Label {
								Text = VM.Description,
								LineBreakMode = LineBreakMode.WordWrap,
								Font = Font.BoldSystemFontOfSize (10)
							}
						}
					},

					beersListView,
					new ActionsMenu (VM.Actions)
				}

			};
		}


	}
}

