using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class RemoveProductFromCart
    {
        public ShoppingCartType Type { get; set; }
        public int ProductId { get; set; }
    }
}
