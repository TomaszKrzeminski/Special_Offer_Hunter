using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class ShopLocationData
    {



        public ShopLocationData()
        {



        }




        public async Task GetLocation(string Latitude, string Longitude)
        {
            string ReverseGeocodingKey = "pk.6a0568ea2a60f5218a864c2d9f7e5432";

            var url1 = "https://us1.locationiq.com/v1/reverse.php?key=" + ReverseGeocodingKey + "&lat=" + Longitude + "&lon=" + Latitude + "&format=json";
            var httpClient1 = new HttpClient();
            HttpResponseMessage response1 = await httpClient1.GetAsync(url1);

            string responseBody1 = await response1.Content.ReadAsStringAsync();

            JObject o = JObject.Parse(responseBody1);

            //ShopLocationData location = new ShopLocationData();
            this.City = (string)o["address"]["town"];
            this.HouseNumber = (string)o["address"]["house_number"];
            this.Country = (string)o["address"]["country"];
            this.PostCode = (string)o["address"]["postcode"];
            this.Street = (string)o["address"]["road"];


        }



        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string PlaceName { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }

        public string SecondHouseNumber { get; set; }
    }
}
