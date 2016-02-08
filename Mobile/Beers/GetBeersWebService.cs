using System;
using STLBrewReview.Mobile.Global;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STLBrewReview.Mobile.Breweries;

namespace STLBrewReview.Mobile.Beers
{
    public class GetBeersWebService:BaseWebService, IGetBeersWebService
    {
        public event EventHandler BeersReceived = delegate {};

        public GetBeersWebService()
        {
        }

        public GetBeersWebService(IWebClient webClient)
            : base(webClient)
        {
        }

        public void Execute(string breweryShortName)
        {
            WebClient.ResponseReceived += (object sender, EventArgs e) =>
            {
//				string jsonText = (e as WebClientResultEventArgs).Response;
//
//				var settings = new JsonSerializerSettings (){ NullValueHandling = NullValueHandling.Ignore };
//				List<Beer> beers = JsonConvert.DeserializeObject<Brewery> (jsonText, settings).beers;
//				BeersReceived (this, new BeersReceivedEventArgs (beers));
            };
            WebClient.Get(serviceURLRoot + "breweries/" + breweryShortName + ".json");
        }
    }

    public interface IGetBeersWebService
    {
        event EventHandler BeersReceived;

        void Execute(string breweryShortName);
    }

    public class BeersReceivedEventArgs:EventArgs
    {
        public readonly List<Beer> Beers;

        public BeersReceivedEventArgs(List<Beer> beers)
        {
            Beers = beers;
        }

    }
}

