using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{

    public enum PriceDescription
    {
        Lower,Higher,All
    }



    public class SpecialOfferViewModel
    {
        

        public Expression<Func<Shop, bool>> SearchShopByDistance;
        public Expression<Func<Shop, bool>> SearchShop;
        public Expression<Func<Product, bool>> SearchProductByCategory;
        public Expression<Func<Product, bool>> SearchProductByProductName;
        public Expression<Func<Product, bool>> SearchProductByPrice;
       
          
        public SpecialOfferViewModel()
        {
            Distance = 2;
            list = new List<Product>();
            priceDescription = PriceDescription.All;
            CategoryName = "";
            ShopName = "";
            ProductName = "";
            PriceValue = 0;
        }

        public ProductCategory category;
        public int Distance { get; set; }
        public string CategoryName { get; set; }
        public string ShopName { get; set; }
        public string ProductName { get; set; }

        public double PriceValue { get; set; }  
        public PriceDescription priceDescription { get; set; }

        public List<Product> list { get; set; }
    }
}
