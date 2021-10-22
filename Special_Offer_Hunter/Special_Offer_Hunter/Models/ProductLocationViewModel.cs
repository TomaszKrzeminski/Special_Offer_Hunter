using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
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



    }
}
