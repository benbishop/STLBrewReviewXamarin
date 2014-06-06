using System;
using System.Collections.Generic;
using STLBrewReview.Mobile.Global;
using Newtonsoft.Json;

namespace STLBrewReview.Mobile.Breweries
{
	public class GetBreweriesWebService:BaseWebService, IGetBreweriesWebService
	{

		public event EventHandler BreweriesReceived = delegate{};

		public GetBreweriesWebService ()
		{
		}

		public virtual void Execute ()
		{
			WebClient.ResponseReceived += (object sender, EventArgs e) => {
				string jsonText = (e as WebClientResultEventArgs).Response;
				List<Brewery> breweries = JsonConvert.DeserializeObject<List<Brewery>> (jsonText);
				BreweriesReceived (this, new BreweriesReceivedEventArgs (breweries));
			};
			WebClient.Get (serviceURLRoot + "breweries.json");
		}
	}

	public interface IGetBreweriesWebService
	{
		event EventHandler BreweriesReceived;

		void Execute ();
	}

	public class BreweriesReceivedEventArgs:EventArgs
	{
		public readonly List<Brewery> Breweries;

		public BreweriesReceivedEventArgs (List<Brewery> breweries)
		{
			Breweries = breweries;
		}

	}
}

