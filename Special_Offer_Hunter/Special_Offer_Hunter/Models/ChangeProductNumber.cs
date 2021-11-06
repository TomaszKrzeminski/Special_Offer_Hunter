using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{

    public class ChangeProductNumber
    {
        public double number { get; set; }

        public int ProductId { get; set; }

        public double ProductPrice { get; set; }

        public ShoppingCartType type { get; set; }


    }
}
