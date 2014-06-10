using System;
using Xamarin.Forms;
using MonkeyArms;
using STLBrewReview.Mobile.Global;
using STLBrewReview.Mobile.Breweries.Detail;
using System.Collections.ObjectModel;

namespace STLBrewReview.Mobile.Beers
{
	public class GetBeersCommand:MonkeyArms.Command
	{

		[Inject]
		public IGetBeersWebService WebService;

		public GetBeersCommand ()
		{
		}

		public override void Execute (InvokerArgs args)
		{
			BreweryDetailsViewModel VM = (args as ViewModelInvokerArgs).ViewModelAs<BreweryDetailsViewModel> ();
			WebService.BeersReceived += (object sender, EventArgs e) => {
				VM.Beers = new ObservableCollection<Beer> ((e as BeersReceivedEventArgs).Beers);
				VM.Ready = true;
			};
			WebService.Execute (VM.BreweryShortname);
		}
	}
}

