using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class ProductDetailsFromBarCode
    {
      public  string BarCode { get; set; }
      public  string ProductName { get; set; }

      public async Task<Product> GetProductDetails(string barcode= "5900571902299")
        {
            Product product = new Product();
            product.Description="Nie udało się znaleźć żadnych informacji o produkcie";
            
            try
            {
                var httpClient = new HttpClient();

                var url = "https://world.openfoodfacts.org/api/v0/product/" + barcode + ".json";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(responseBody);

               
                //product.Name = (string)o["product"]["_keywords"];
                product.Name = (string)o["product"][1];
                product.Description =(string)o["product"]["brands"];
                //weather.City = (string)o["name"];
                //weather.Temp = (double)o["main"]["temp"];
                //weather.Temp_Min = (double)o["main"]["temp_min"];
                //weather.Temp_Max = (double)o["main"]["temp_max"];
                //weather.Description = (string)o["weather"][0]["description"];




                return product;
            }
            catch(Exception ex)
            {
                return product;
            }


        }






    }
}
