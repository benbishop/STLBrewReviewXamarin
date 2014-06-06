using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace STLBrewReview.Mobile.Global
{
	public class BaseViewModel:INotifyPropertyChanged, INotifyPropertyChanging
	{


		public BaseViewModel ()
		{
		}

		private string title = string.Empty;
		public const string TitlePropertyName = "Title";

		/// <summary>
		/// Gets or sets the "Title" property
		/// </summary>
		/// <value>The title.</value>
		public string Title {
			get { return title; }
			set { SetProperty (ref title, value, TitlePropertyName); }
		}

		protected void SetProperty<T> (
			ref T backingStore, T value,
			string propertyName,
			Action onChanged = null,
			Action<T> onChanging = null)
		{


			if (EqualityComparer<T>.Default.Equals (backingStore, value))
				return;

			if (onChanging != null)
				onChanging (value);

			OnPropertyChanging (propertyName);

			backingStore = value;

			if (onChanged != null)
				onChanged ();

			OnPropertyChanged (propertyName);
		}

		#region INotifyPropertyChanging implementation

		public event PropertyChangingEventHandler PropertyChanging;

		#endregion

		public void OnPropertyChanging (string propertyName)
		{
			if (PropertyChanging == null)
				return;

			PropertyChanging (this, new PropertyChangingEventArgs (propertyName));
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged = delegate {};

		#endregion


		public void OnPropertyChanged (string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}
	}
}

