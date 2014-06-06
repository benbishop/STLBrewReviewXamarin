using System;
using STLBrewReview.Mobile.Global;
using System.Collections.ObjectModel;

namespace STLBrewReview.Mobile.Breweries
{
	public class BreweriesListViewModel:BaseViewModel
	{
		public static string BreweriesPropName = "Breweries";

		public BreweriesListViewModel ()
		{
			Title = "Breweries";
		}

		private ObservableCollection<Brewery> breweries = new ObservableCollection<Brewery> ();

		/// <summary>
		/// gets or sets the feed items
		/// </summary>
		public virtual ObservableCollection<Brewery> Breweries {
			get { return breweries; }
			set {
				breweries = value;
				OnPropertyChanged (BreweriesPropName);
			}
		}
	}


}

