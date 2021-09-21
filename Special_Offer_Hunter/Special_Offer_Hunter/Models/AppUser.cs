using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class ApplicationUser : IdentityUser
    {


        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime Dateofbirth { get; set; }


      


        public ApplicationUser()
        {
            Shopping_Cart_Day = new List<Shopping_Cart_Day>();
            Shopping_Cart_Week = new List<Shopping_Cart_Week>();

        }

        public virtual List<Shopping_Cart_Day> Shopping_Cart_Day { get; set; }
        public virtual List<Shopping_Cart_Week> Shopping_Cart_Week { get; set; }


    }


    public class Category          
         {


        public Category()
        {
            ProductCategory = new List<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual List<ProductCategory> ProductCategory { get; set; }
         }



    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }




    public class Shop
    {
        public Shop()
        {
            Comments = new List<Shop_Comment>();
            Ranks = new List<Shop_Rank>();
            Products = new List<Product>();

        }
        public int ShopId { get; set; }
        public string Name { get; set; }

        public virtual List<Shop_Comment> Comments { get; set; }
        public virtual List<Shop_Rank> Ranks { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual Location Location { get; set; }
       

    }



    public class Product_Price
    {

        public Product_Price()
        {
            SpecialOffer = false;
            SpecialOffer_Description = "";
            Products = new List<Product>();
        }

        public Product_Price(double Price,bool SpecialOffer=false,string SpecialOffer_Description="")
        {
            this.Price = Price;
            this.SpecialOffer = SpecialOffer;            
            this.SpecialOffer_Description = SpecialOffer_Description;
            Products = new List<Product>();
        }

        public int Product_PriceId { get; set; }
        public double Price { get; set; }
        public bool SpecialOffer { get; set; }

        public double LastPrice { get; set; }
        public string SpecialOffer_Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }



    public class Product
    {

        public Product()
        {
            Comments = new List<Product_Comment>();
            Ranks = new List<Product_Rank>();
            ProductCategory = new List<ProductCategory>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
       

        public string Description { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public string Picture { get; set; }
        public virtual List<Product_Comment> Comments { get; set; }
        public virtual List<Product_Rank> Ranks { get; set; }
        public virtual List<ProductCategory> ProductCategory { get; set; }
        public virtual Product_Code Product_Code { get; set; }

        public int? Shopping_Cart_DayId { get; set; }
        public  Shopping_Cart_Day shopping_Cart_Day;

        public int? Shopping_Cart_WeekId { get; set; }
        public  Shopping_Cart_Week shopping_Cart_Week;

        public int? ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        public int? Product_PriceId { get; set; }
        public virtual Product_Price Product_Price { get; set; }

    }


    public class Location
    {


        public Location()
        {
            Country = "Polska";
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string SecondNumber { get; set; }
        public virtual Shop Shop { get; set; }
        public int? ShopLocationId { get; set; } 
    }

    public class Shopping_Cart_Day
    {


        public Shopping_Cart_Day()
        {
            Products = new List<Product>();
        }

        public int Shopping_Cart_DayId { get; set; }
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual List<Product> Products { get; set; }
    }


    public class Shopping_Cart_Week
    {

        public Shopping_Cart_Week()
        {
            Products = new List<Product>();
        }

        public int Shopping_Cart_WeekId { get; set; }
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Product> Products { get; set; }
    }

    public class Product_Code
    {
        public int Product_CodeId { get; set; }
        public string Code { get; set; }
        public string CodeType { get; set; }
        public string Country { get; set; }
        public string Producer { get; set; }

        public string ProductInfo { get; set; }

        public int? ProductCodeId{get;set;}
        public virtual Product Product { get; set; }
    }

    public class Product_Rank
    {
        public int Product_RankId { get; set; }
        public string Name { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

    public class Shop_Rank
    {
        public int Shop_RankId { get; set; }
        public string Name { get; set; }

        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }


    public class Shop_Comment
    {
        public int Shop_CommentId { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }

    }

    public class Product_Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }




   
}

