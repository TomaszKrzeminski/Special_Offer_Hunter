using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class AddShopViewModel
    {
        public Shop shop { get; set; }
        public string UserId { get; set; }

        public Location ShopLocation { get; set; }

    }
}
