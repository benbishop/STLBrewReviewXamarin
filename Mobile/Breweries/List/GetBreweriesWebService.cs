using System;
using System.Collections.Generic;
using STLBrewReview.Mobile.Global;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace STLBrewReview.Mobile.Breweries.List
{
    public class GetBreweriesWebService:BaseWebService, IGetBreweriesWebService
    {

        public event EventHandler BreweriesReceived = delegate{};

        public GetBreweriesWebService()
        {
        }

        public GetBreweriesWebService(IWebClient webClient)
            : base(webClient)
        {
        }

        public virtual void Execute()
        {
			
            var assembly = typeof(GetBreweriesWebService).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("STLBrewReview.Mobile.Json.Brewery.json");
            string jsonText = "";
            try
            {
                var reader = new System.IO.StreamReader(stream);
                jsonText = reader.ReadToEnd();
                List<Brewery> breweries = JsonConvert.DeserializeObject<List<Brewery>>(jsonText, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore });
                BreweriesReceived(this, new BreweriesReceivedEventArgs(breweries));

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong");
            }

        }
    }

    public interface IGetBreweriesWebService
    {
        event EventHandler BreweriesReceived;

        void Execute();
    }

    public class BreweriesReceivedEventArgs:EventArgs
    {
        public readonly List<Brewery> Breweries;

        public BreweriesReceivedEventArgs(List<Brewery> breweries)
        {
            Breweries = breweries;
        }

    }
}

