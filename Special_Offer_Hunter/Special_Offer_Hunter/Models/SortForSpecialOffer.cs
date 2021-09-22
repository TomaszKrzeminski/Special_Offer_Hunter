using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{


    public class SortintOffers
    {




    }


    public interface SingleSort
    {
        SingleSort Next { get; set; }
        void SetNextSortObject(SingleSort sort);
        void SetSorting(SpecialOfferViewModel model);


    }

    public class SortDistance : SingleSort
    {
        Expression<Func<Shop, bool>>
      SearchShopByDistance(double Distance)
        {
            return (Shop c) => 
            true;
        }
        public SingleSort Next { get; set; }

        public void SetNextSortObject(SingleSort sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {
            
            if(model.Distance>0)
            {

                model.SearchShopByDistance = SearchShopByDistance(model.Distance);
            }

            if (Next != null)
            {
 Next.SetSorting(model);
            }
           
        }
    }


    public class SortCategoryName : SingleSort
    {
        Expression<Func<Product, bool>>
       SearchProductByCategoryOne(string Category)
        {
            return (Product c) => c.ProductCategory.Any(x => x.Category.Name == Category);
        }

        Expression<Func<Product, bool>>
SearchProductByCategoryAll(string Category)
        {
            return (Product c) => true;
        }



        public SingleSort Next { get; set; }

        public void SetNextSortObject(SingleSort sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {

            if (model.CategoryName =="")
            {
                model.SearchProductByCategory = SearchProductByCategoryAll(model.CategoryName);
            }
            else
            {
                model.SearchProductByCategory = SearchProductByCategoryOne(model.CategoryName);
            }

            if (Next != null)
            {
 Next.SetSorting(model);
            }
           
        }
    }


    public class SortShopName : SingleSort
    {

        Expression<Func<Shop, bool>>
         SearchShopOne(string Name)
        {
            return (Shop s) => s.Name == Name;


        }


        Expression<Func<Shop, bool>>
     SearchShopAll(string Name)
        {
            return (Shop s) => true;
        }



        public SingleSort Next { get; set; }

        public void SetNextSortObject(SingleSort sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {

            if (model.ShopName == "")
            {
                model.SearchShop = SearchShopAll(model.ShopName);
            }
            else
            {
                model.SearchShop = SearchShopOne(model.ShopName);
            }

            if (Next != null)
            {
 Next.SetSorting(model);
            }
           
        }
    }


    public class SortProductName : SingleSort
    {

        Expression<Func<Product, bool>>
SearchProductByProductNameOne(string productName)
        {
            return (Product c) => c.Name == productName;
        }

        Expression<Func<Product, bool>>
SearchProductByProductNameAll(string productName)
        {
            return (Product c) => true;
        }

        public SingleSort Next { get ; set; }

        public void SetNextSortObject(SingleSort sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {

            if (model.ProductName =="")
            {
                model.SearchProductByProductName = SearchProductByProductNameAll(model.ProductName);
            }
            else
            {
                model.SearchProductByProductName = SearchProductByProductNameOne(model.ProductName);
            }

            if (Next != null)
            {
 Next.SetSorting(model);
            }
           
        }
    }

    public class SortPriceValue : SingleSort
    {


        Expression<Func<Product, bool>>
SearchProductByPriceHigher(double productPrice)
        {
            return (Product c) => c.Product_Price.Price > productPrice;
        }

        Expression<Func<Product, bool>>
SearchProductByPriceLower(double productPrice)
        {
            return (Product c) => c.Product_Price.Price < productPrice;
        }

        Expression<Func<Product, bool>>
SearchProductByPriceAll(double productPrice)
        {
            return (Product c) => true;
        }

        public SingleSort Next { get; set; }

        public void SetNextSortObject(SingleSort sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {

            if (model.priceDescription==PriceDescription.All)
            {
                model.SearchProductByPrice = SearchProductByPriceAll(model.PriceValue);
            }
            else if(model.priceDescription == PriceDescription.Lower)
            {
                model.SearchProductByPrice = SearchProductByPriceLower(model.PriceValue);
            }
            else
            {
                model.SearchProductByPrice = SearchProductByPriceHigher(model.PriceValue);
            }

            if(Next!=null)
            {
 Next.SetSorting(model);
            }

           
        }
    }






    //public interface SortForSpecialOffer
    //{
      
    //    public int Distance { get; set; }
    //    public string CategoryName { get; set; }
    //    public string ShopName { get; set; }
    //    public string ProductName { get; set; }
    //    public double PriceValue { get; set; }
    //    public PriceDescription priceDescription { get; set; }

    //    public List<Product> list { get; set; }


    //    void  SetSortByShopDistance(int Distance);
    //    void SetSortByShopName(string ShopName);
    //    void SetSortByProductCategoryName(string ProductCategory);       
    //    void SetSortByProductName(string ProductName);
    //    void SetSortByProductPrice(double ProductPrice);







    //}
}
