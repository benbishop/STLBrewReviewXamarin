﻿using System;
using System.Runtime.Serialization;
using STLBrewReview.Mobile.Beers;
using System.Collections.Generic;

namespace STLBrewReview.Mobile.Breweries
{
    [DataContract(Name = "brewery")]
    public class Brewery
    {
        [DataMember(Name = "name")] 
        public string name{ get; set; }

        [DataMember(Name = "phone")] 
        public string phone{ get; set; }

        [DataMember(Name = "twitter_handle")] 
        public string twitter_handle{ get; set; }

        [DataMember(Name = "short_name")] 
        public string short_name{ get; set; }

        [DataMember(Name = "objectId")] 
        public string objectId{ get; set; }

        //        [DataMember(Name = "updated_at")]
        //        public DateTime updated_at{ get; set; }

        [DataMember(Name = "address")] 
        public string address{ get; set; }

        [DataMember(Name = "email")] 
        public string email{ get; set; }

        [DataMember(Name = "image_url")] 
        public string image_url{ get; set; }

        [DataMember(Name = "rss_url")] 
        public string rss_url{ get; set; }

        [DataMember(Name = "description")] 
        public string description{ get; set; }

        //        [DataMember(Name = "created_at")]
        //        public DateTime created_at{ get; set; }

        //        [DataMember(Name = "beers")]
        //        public List<Beer> beers{ get; set; }

        //		[DataMember (Name = "image_left")]
        //		public int image_left{ get; set; }
        //
        //		[DataMember (Name = "image_top")]
        //		public int image_top{ get; set; }

        [DataMember(Name = "website_url")] 
        public string website_url{ get; set; }

        [DataMember(Name = "facebook_url")] 
        public string facebook_url{ get; set; }

        public Brewery()
        {
        }
    }
}

