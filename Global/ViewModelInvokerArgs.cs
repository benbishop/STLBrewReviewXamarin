using System;
using MonkeyArms;

namespace STLBrewReview.Mobile.Global
{
	public class ViewModelInvokerArgs:InvokerArgs
	{
		public readonly BaseViewModel ViewModel;

		public ViewModelInvokerArgs (BaseViewModel vm)
		{
			ViewModel = vm;
		}

		public TAsType ViewModelAs<TAsType> () where TAsType:class
		{
			return ViewModel as TAsType;
		}
	}
}

