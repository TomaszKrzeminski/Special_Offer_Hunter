using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Special_Offer_Hunter.Models
{

    public enum SortType
    {
        Rosnąco, Malejąco
    }

    public enum PriceDescription
    {
        Niższa, Wyższa, Wszystkie
    }

    public enum SortMethod
    {
        Brak, Cena, Nazwa, Odległość, Sklep
    }

    public class SpecialOfferViewModel
    {


        public Expression<Func<Shop, bool>> SearchShopByDistance;
        public Expression<Func<Shop, bool>> SearchShop;
        public Expression<Func<Product, bool>> SearchProductByBarCode;
        public Expression<Func<Product, bool>> SearchProductBySpecialOffer;
        public Expression<Func<Product, bool>> SearchProductByCategory;
        public Expression<Func<Product, bool>> SearchProductByProductName;
        //public Expression<Func<Product, bool>> SearchProductByPrice;
        public Expression<Func<Product, bool>> SearchProductByPrice;


        public Func<KeyValuePair<Product, double>, object> SortProduct;
        //public Expression<Func<double, double>> SortByDistance;


        public SpecialOfferViewModel()
        {
            Distance = 2;
            list = new List<Product>();
            priceDescription = PriceDescription.Wszystkie;
            CategoryName = "";
            ShopName = "";
            ProductName = "";
            PriceValue = 0;
            sortType = SortType.Rosnąco;
            SpecialOffer = false;
        }
        public SelectList CategoryList { get; set; }

        public ProductCategory category;
        public Location MyLocation { get; set; }
        public double Distance { get; set; }
        public string CategoryName { get; set; }
        public string ShopName { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }

        public double PriceValue { get; set; }
        public PriceDescription priceDescription { get; set; }

        public SortMethod sortMethod { get; set; }

        public SortType sortType { get; set; }

        public bool Descending { get; set; }
        public bool SpecialOffer { get; set; }

        public List<Product> list { get; set; }
        public Dictionary<Product, double> list2 { get; set; }

        public List<Shop> shopList { get; set; }
    }
}
