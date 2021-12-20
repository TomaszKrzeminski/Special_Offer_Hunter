using Special_Offer_Hunter.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{

    public class ShopLocationViewModel
    {

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location UserLocation { get; set; }

    }







    public class ProductLocationViewModel
    {
        public ProductLocationViewModel()
        {
            list = new List<ProductLocation>();
        }
        public ShoppingCartType shoppingcartType { get; set; }
        public Location UserLocation { get; set; }
        public List<ProductLocation> list { get; set; }

        public string JsonShops { get; set; }
        public List<Places> listPlaces { get; set; }
        public string Distance { get; set; }
        public string Time { get; set; }

        public string ArrivalTime { get; set; }




        public string SetDistance(Root root)
        {
            string x = "";
            try
            {
                if (root.routes != null)
                {
                    x = (root.routes[0].summary.lengthInMeters / 1000).ToString();
                }
            }
            catch (Exception ex)
            {

            }

            return x;

        }

        public string SetTimeMinutes(Root root)
        {
            string x = "";

            try
            {
                if (root.routes != null)
                {
                    x = (root.routes[0].summary.travelTimeInSeconds / 60).ToString();
                }
            }
            catch (Exception ex)
            {

            }


            return x;

        }


        public string SetTimeArrival(Root root)
        {
            string x = "";
            try
            {
                if (root.routes != null)
                {
                    x = (root.routes[0].summary.arrivalTime).ToString();
                }
            }
            catch (Exception ex)
            {

            }


            return x;

        }


    }
}
