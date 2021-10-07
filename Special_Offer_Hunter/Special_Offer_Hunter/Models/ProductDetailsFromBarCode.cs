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

      public async Task<ProductDetailsViewModel> GetProductDetails(string barcode)
        {
            ProductDetailsViewModel model = new ProductDetailsViewModel();
            model.Description="Nie udało się znaleźć żadnych informacji o produkcie";
            model.Code = "";
            model.Brand = "";       
            
            try
            {
                var httpClient = new HttpClient();

                var url = "https://world.openfoodfacts.org/api/v0/product/" + barcode + ".json";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(responseBody);

                string code = (string)o["code"];

               
 JArray array = (JArray)o["product"]["_keywords"];
                string brands = (string)o["product"]["brands"];
                

               
                model. Description = "";
                model.Brand = brands;
                model.Code = code;


                if(array!=null)
                {
for (int i = 0; i < array.Count; i++)
                {
                    model.Description += " " + array[i];
                    
                }   
                }

                         


                return model;
            }
            catch(Exception ex)
            {
                return model;
            }


        }






    }
}
