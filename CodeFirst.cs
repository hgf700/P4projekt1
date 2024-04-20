using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace p4
{
    public class UserRegister
    {
        [Key]
        public int UserID { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public virtual ICollection<Restaurant> LikedRestaurants { get; set; }
        public int LikedRestaurants { get; set; }
    }

    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        [JsonProperty("is_closed")]
        public bool Isclosed { get; set; }
        [JsonProperty("name")]
        public string Nameofrestaurant { get; set; }
        [JsonProperty("image_url")]
        public string Imageurlofrestaurant { get; set; }
        [JsonProperty("url")]
        public string Urlofrestaurant { get; set; }
        [JsonProperty("review_count")]
        public string Reviewcount { get; set; }
        [JsonProperty("rating")]
        public string Rating { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("address1")]
        public string Adressofrestaurant { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("phone")]
        public string Phonenumber { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("longitude")]
        public string Longtitude { get; set; }
        public string LocalizationMapURL {  get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<UserRegister> UserData { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
