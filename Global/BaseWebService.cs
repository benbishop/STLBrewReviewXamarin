using System;
using MonkeyArms;
using System.Diagnostics;

namespace STLBrewReview.Mobile.Global
{
	public class BaseWebService:IInjectingTarget
	{

		[Inject]
		public IWebClient WebClient;

		protected const string serviceURLRoot = "http://stlbrewreview.com/saint_louis/";

		public BaseWebService ()
		{
			DIUtil.InjectProps (this);
		}

		public BaseWebService (IWebClient webClient)
		{
			WebClient = webClient;
		}




	}
}

