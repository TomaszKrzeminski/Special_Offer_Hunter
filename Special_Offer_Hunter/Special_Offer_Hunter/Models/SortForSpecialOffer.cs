using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{




   

   


    public interface SingleSearch
    {
        SingleSearch Next { get; set; }
        void SetNextSortObject(SingleSearch sort);
        void SetSorting(SpecialOfferViewModel model);


    }

 

    public class SearchCategoryName : SingleSearch
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



        public SingleSearch Next { get; set; }

        public void SetNextSortObject(SingleSearch sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {

            if (model.CategoryName ==""||model.CategoryName==null)
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


    public class SearchShopName : SingleSearch
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



        public SingleSearch Next { get; set; }

        public void SetNextSortObject(SingleSearch sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {

            if (model.ShopName == ""||model.ShopName==null)
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


    public class SearchProductName : SingleSearch
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

        public SingleSearch Next { get ; set; }

        public void SetNextSortObject(SingleSearch sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {

            if (model.ProductName ==""||model.ProductName==null)
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

    public class SearchPriceValue : SingleSearch
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

        public SingleSearch Next { get; set; }

        public void SetNextSortObject(SingleSearch sort)
        {
            this.Next = sort;
        }

        public void SetSorting(SpecialOfferViewModel model)
        {

            if (model.priceDescription==PriceDescription.Wszystkie)
            {
                model.SearchProductByPrice = SearchProductByPriceAll(model.PriceValue);
            }
            else if(model.priceDescription == PriceDescription.Niższa)
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


  
}
