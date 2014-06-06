using System;
using System.Net;
using System.Net.Http;

namespace STLBrewReview.Mobile.Global
{
	public class SimpleWebClient:IWebClient
	{
		public SimpleWebClient ()
		{
		}

		#region IWebClient implementation

		public event EventHandler ResponseReceived = delegate {};

		public async void Get (string url)
		{
			var client = new HttpClient ();
			var responseString = await client.GetStringAsync (url);
			ResponseReceived (this, new WebClientResultEventArgs (true, responseString));
		}

		#endregion
	}
}

