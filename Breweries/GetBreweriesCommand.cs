using System;
using MonkeyArms;
using System.Collections.ObjectModel;


namespace STLBrewReview.Mobile.Breweries
{
	public class GetBreweriesCommand:Command
	{

		[Inject]
		public IGetBreweriesWebService WebService;

		[Inject]
		public BreweriesViewModel VM;

		#region implemented abstract members of Command

		public override void Execute (InvokerArgs args)
		{
			WebService.BreweriesReceived += (object sender, EventArgs e) => {
				VM.Breweries = new ObservableCollection<Brewery> ((e as BreweriesReceivedEventArgs).Breweries);
			};
			WebService.Execute ();
		}

		#endregion
	}
}

