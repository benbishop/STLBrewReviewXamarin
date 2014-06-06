using System;
using System.Runtime.Serialization;

namespace STLBrewReviewMobile
{
	[DataContract (Name = "beer")]
	public class Beer
	{
		[DataMember (Name = "appearance")] 
		public string appearance{ get; set; }

		[DataMember (Name = "site_link_url")] 
		public string site_link_url{ get; set; }

		[DataMember (Name = "malts")] 
		public string malts{ get; set; }

		[DataMember (Name = "short_name")] 
		public string short_name{ get; set; }

		[DataMember (Name = "hops")] 
		public string hops{ get; set; }

		[DataMember (Name = "ibu")] 
		public int ibu{ get; set; }

		[DataMember (Name = "process")] 
		public string process{ get; set; }

		[DataMember (Name = "id")] 
		public int id{ get; set; }

		[DataMember (Name = "srm")] 
		public decimal srm{ get; set; }

		[DataMember (Name = "created_at")] 
		public DateTime created_at{ get; set; }

		[DataMember (Name = "updated_at")] 
		public DateTime updated_at{ get; set; }

		[DataMember (Name = "abv")] 
		public decimal abv{ get; set; }

		[DataMember (Name = "og")] 
		public decimal og{ get; set; }

		[DataMember (Name = "brewery_id")] 
		public int brewery_id{ get; set; }

		[DataMember (Name = "image_url")] 
		public string image_url{ get; set; }

		[DataMember (Name = "in_production")] 
		public bool in_production{ get; set; }

		[DataMember (Name = "description")] 
		public string description{ get; set; }

		[DataMember (Name = "name")] 
		public string name{ get; set; }

		[DataMember (Name = "yeast")] 
		public string yeast{ get; set; }

		public Beer ()
		{
		}
	}
}

