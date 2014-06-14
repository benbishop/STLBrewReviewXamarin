using System;
using Xamarin.Forms;
using STLBrewReviewMobile.Android;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Graphics;
using Android.App;
using Android.AccessibilityServices;
using System.Threading.Tasks;
using System.Net.Http;


[assembly: ExportRenderer (typeof(ImageCell), typeof(BrewReviewImageCellRenderer))]
namespace STLBrewReviewMobile.Android
{
	public class BrewReviewImageCellRenderer:ImageCellRenderer
	{
		public BrewReviewImageCellRenderer ()
		{
		}

		protected override global::Android.Views.View GetCellCore (Cell item, global::Android.Views.View convertView, global::Android.Views.ViewGroup parent, global::Android.Content.Context context)
		{

			var view = (context as Activity).LayoutInflater.Inflate (Resource.Layout.ImageCell, null);

			view.FindViewById<TextView> (Resource.Id.titleTextView).Text = (item as TextCell).Text;
			UriImageSource source = ((item as ImageCell).ImageSource as UriImageSource);
			if (source != null) {
				var uri = source.Uri as System.Uri;
				LoadImageFromInternet (view.FindViewById<ImageView> (Resource.Id.imageView), uri.AbsoluteUri);
			}

			return view;
		}

		async void LoadImageFromInternet (ImageView imgView, string url)
		{


			using (var bm = await GetImageFromUrl (url))
				imgView.SetImageBitmap (bm);
		}

		private async Task<Bitmap> GetImageFromUrl (string url)
		{
			using (var client = new HttpClient ()) {
				var msg = await client.GetAsync (url);
				if (msg.IsSuccessStatusCode) {
					using (var stream = await msg.Content.ReadAsStreamAsync ()) {
						﻿
						var bitmap = await BitmapFactory.DecodeStreamAsync (stream);
						return bitmap;
					}
				}
			}
			return null;
		}
	}
}

