using System;

namespace STLBrewReview.Mobile.Global
{
	public interface IWebClient
	{
		void Get (string url);

		event EventHandler ResponseReceived;
	}

	public class WebClientResultEventArgs:EventArgs
	{
		public readonly bool Success;

		public readonly string Response;

		public WebClientResultEventArgs (bool success, string response)
		{
			Success = success;
			Response = response;
		}
	}
}

