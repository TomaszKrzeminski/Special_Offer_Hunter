using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{

    public enum ShoppingCartType
    {
        Dzień, Tydzień, Miesiąc, Rok, Poszukiwane
    }

    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            //cartDay = new Shopping_Cart_Day();
            //cartWeek = new Shopping_Cart_Week();
            //cartYear = new Shopping_Cart_Year();
            //cartMonth = new Shopping_Cart_Month();
            //cartLookFor = new Shopping_Cart_LookFor();
            productList = new List<Product>();
            type = ShoppingCartType.Dzień;
        }
        //public Shopping_Cart_Day cartDay { get; set; }
        //public Shopping_Cart_Week cartWeek { get; set; }
        //public Shopping_Cart_Month cartMonth { get; set; }
        //public Shopping_Cart_Year cartYear { get; set; }
        //public Shopping_Cart_LookFor cartLookFor { get; set; }
        public string UserId { get; set; }
        public ShoppingCartType type { get; set; }
        public List<Product> productList { get; set; }



    }
}
