using System;
using STLBrewReview.Mobile.Global;
using Xamarin.Forms;
using System.Collections.Generic;
using MonkeyArms;
using Xamarin.Forms.Maps;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using STLBrewReview.Mobile.Beers;

namespace STLBrewReview.Mobile.Breweries.Detail
{
	public class BreweryDetailsView:BaseView
	{
		public Action<string> MakePhoneCall = delegate {
		};

		public Action<string> OpenEmail = delegate {
		};

		public Action<string> LaunchMapApp = delegate {

		};



		protected readonly BreweryDetailsViewModel VM;

		public BreweryDetailsView (BreweryDetailsViewModel vm)
		{
			BindingContext = VM = vm;

			BuildUI ();
		}



		protected void BuildUI ()
		{




			var beersListView = new ListView {
				RowHeight = 40,
				ItemTemplate = new DataTemplate (typeof(BeerCell))
			};

			beersListView.SetBinding (ListView.ItemsSourceProperty, new Xamarin.Forms.Binding (BreweryDetailsViewModel.BeersPropName));
			beersListView.ItemTemplate.SetBinding (ImageCell.TextProperty, new Xamarin.Forms.Binding ("name"));
			beersListView.ItemTemplate.SetBinding (ImageCell.ImageSourceProperty, new Xamarin.Forms.Binding ("image_url"));
			beersListView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				Navigation.PushAsync (new BeerDetailsView (new BeerDetailsViewModel (e.Item as Beer)));
			};


			var actionsMenu = new ActionsMenu (VM.Actions);
			actionsMenu.ActionTapped += (action) => {
				ResolveActionTap (action);
			};


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
								TextColor = Color.Black,
								Text = VM.Description,
								LineBreakMode = LineBreakMode.WordWrap,
								Font = Font.BoldSystemFontOfSize (12)
							}
						}

					},

					beersListView,
					actionsMenu
				}

			};
		}


		protected void ResolveActionTap (string action)
		{
			switch (action) {
			case BreweryDetailsViewModel.ACTIONPHONE:
				MakePhoneCall (VM.PhoneNumberURL);
				break;
			case BreweryDetailsViewModel.ACTIONEMAIL:
				OpenEmail (VM.Email);
				break;
			case BreweryDetailsViewModel.ACTIONMAP:
				LaunchMapApp (VM.Address);
				break;

			case BreweryDetailsViewModel.ACTIONFACEBOOK:
				this.Navigation.PushAsync (new WebsiteView (VM.FacebookURL, "Facebook"));
				break;
			case BreweryDetailsViewModel.ACTIONTWITTER:
				this.Navigation.PushAsync (new WebsiteView (VM.TwitterURL, "Twitter"));
				break;
			case BreweryDetailsViewModel.ACTIONWEBSITE:
				this.Navigation.PushAsync (new WebsiteView (VM.WebsiteURL, "Website"));
				break;
			}
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			DI.Get<RequestBeersInvoker> ().Invoke (new ViewModelInvokerArgs (VM));
		}

	}
}

