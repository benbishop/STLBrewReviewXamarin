using System;
using Xamarin.Forms;
using MonkeyArms;
using STLBrewReview.Mobile.Global;
using STLBrewReview.Mobile.Breweries.Detail;

namespace STLBrewReview.Mobile.Breweries.List
{
	public class BreweriesListView:BaseView
	{
		BreweriesListViewModel VM;

		public BreweriesListView ()
		{
			BindingContext = VM = DI.Get<BreweriesListViewModel> ();

			var listView = new ListView {
				RowHeight = 40,
				ItemTemplate = new DataTemplate (typeof(TextCell))

			};

			listView.SetBinding (ListView.IsVisibleProperty, new Binding (BaseViewModel.ReadyPropertyName));
			listView.SetBinding (ListView.ItemsSourceProperty, new Binding (BreweriesListViewModel.BreweriesPropName));
			listView.ItemTemplate.SetBinding (TextCell.TextProperty, new Binding ("name"));


			listView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				Navigation.PushAsync (new BreweryDetailsView (new BreweryDetailsViewModel (e.Item as Brewery)));
			};

			Content = new StackLayout {
				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { listView }
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			DI.Get<RequestBreweriesInvoker> ().Invoke (new ViewModelInvokerArgs (VM));
		}


	}
}

