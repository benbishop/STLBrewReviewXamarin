using System;
using STLBrewReview.Mobile.Global;
using System.Collections.ObjectModel;

namespace STLBrewReview.Mobile.Breweries.List
{
	public class BreweriesListViewModel:BaseViewModel
	{
		public static string BreweriesPropName = "Breweries";

		public BreweriesListViewModel ()
		{
			Title = "Breweries";
		}

		private ObservableCollection<Brewery> breweries = new ObservableCollection<Brewery> ();

		public virtual ObservableCollection<Brewery> Breweries {
			get { return breweries; }
			set {
				breweries = value;
				OnPropertyChanged (BreweriesPropName);
			}
		}
	}


}

