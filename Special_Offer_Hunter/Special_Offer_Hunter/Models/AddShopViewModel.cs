using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            this.ShopLocation.Name = shop.Name;

        }


        public void SetLocation2(Location data)
        {
            this.ShopLocation.SecondNumber = data.SecondNumber== "Podaj dodatkowy numer jeśli istnieje"?data.SecondNumber:"Brak";
            this.ShopLocation.City = data.City;
            this.ShopLocation.Country = data.Country;
            this.ShopLocation.Number = data.Number;
            this.ShopLocation.PostalCode = data.PostalCode;
            this.ShopLocation.Street = data.Street;
            this.ShopLocation.Name = shop.Name;

        }

        [Required(ErrorMessage = "Wskaż na mapie położenie sklepu")]
        public string LongitudeText { get; set; }
       
        public string LatitudeText { get; set; }

        public Location ShopLocation { get; set; }

    }
}
