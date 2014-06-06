using System;
using Xamarin.Forms;

namespace STLBrewReview.Mobile.Global
{
	public class BaseView:ContentPage
	{
		public BaseView ()
		{
			SetBinding (Page.TitleProperty, new Binding (BaseViewModel.TitlePropertyName));
		}
	}
}

