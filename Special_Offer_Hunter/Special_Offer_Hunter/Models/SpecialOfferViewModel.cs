using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{

    



    public class SpecialOfferViewModel
    {
        public SpecialOfferViewModel()
        {
            Distance = 2;
            list = new List<Product>();
        }

        public ProductCategory category;
        public int Distance { get; set; }
        public string Category { get; set; }
        public string Shop { get; set; }

        public List<Product> list { get; set; }
    }
}
