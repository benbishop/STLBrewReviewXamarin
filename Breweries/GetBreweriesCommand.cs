using System;
using MonkeyArms;
using System.Collections.ObjectModel;
using STLBrewReview.Mobile.Global;


namespace STLBrewReview.Mobile.Breweries
{
	public class GetBreweriesCommand:Command
	{

		[Inject]
		public IGetBreweriesWebService WebService;



		#region implemented abstract members of Command

		public override void Execute (InvokerArgs args)
		{
			BreweriesListViewModel VM = (args as ViewModelInvokerArgs).ViewModelAs<BreweriesListViewModel> ();
			WebService.BreweriesReceived += (object sender, EventArgs e) => {
				VM.Breweries = new ObservableCollection<Brewery> ((e as BreweriesReceivedEventArgs).Breweries);
				VM.Ready = true;
			};
			WebService.Execute ();
		}

		#endregion
	}
}

