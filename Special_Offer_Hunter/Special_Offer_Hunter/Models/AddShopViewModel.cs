using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class AddShopViewModel
    {


        public AddShopViewModel()
        {
            shop = new Shop();
            ShopLocation = new Location();
        }


        public Shop shop { get; set; }
        public string UserId { get; set; }


        public void SetLocation(ShopLocationData data)
        {
            this.ShopLocation.SecondNumber = "";
            this.ShopLocation.City = data.City;
            this.ShopLocation.Country = data.Country;
            this.ShopLocation.Number = int.Parse(data.HouseNumber);
            this.ShopLocation.PostalCode = data.PostCode;
            this.ShopLocation.Street = data.Street;

        }


        public Location ShopLocation { get; set; }

    }
}
