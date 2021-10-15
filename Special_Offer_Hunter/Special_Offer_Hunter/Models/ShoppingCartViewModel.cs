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


    public class AddProcutToShoppingCart
    {
        public ShoppingCartType Type { get; set; }
        //public string Type { get; set; }
        public int ProductId { get; set; }

    }

    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {

            productList = new List<Product>();
            type = ShoppingCartType.Dzień;
            Action = true;
        }

        public string UserId { get; set; }
        public ShoppingCartType type { get; set; }
        public List<Product> productList { get; set; }

        public bool Action { get; set; }



    }
}
