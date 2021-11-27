using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{

    public class ProductsBought
    {
        public int ProductsBoughtId { get; set; }
        public ShoppingCartType cartType { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public double Number { get; set; }


        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }


    public class ApplicationUser : IdentityUser
    {


        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string HouseNumber { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public virtual NetTopologySuite.Geometries.Point userlocation { get; set; }

        public override string PhoneNumber { get; set; }

        public string UserImagePath { get; set; }





        public ApplicationUser()
        {

            userlocation = new NetTopologySuite.Geometries.Point(0, 0) { SRID = 4326 };
            Longitude = 0;
            Latitude = 0;


            Shopping_Cart_Days = new List<Shopping_Cart_Day>();
            //Shopping_Cart_Weeks = new List<Shopping_Cart_Week>();
            //Shopping_Cart_Months = new List<Shopping_Cart_Month>();
            //Shopping_Cart_Years = new List<Shopping_Cart_Year>();
            Shopping_Cart_LookFor = new List<Shopping_Cart_LookFor>();
            ProductsBought = new List<ProductsBought>();
            UserShopComments = new List<Shop_Comment>();
            UserShopRanks = new List<Shop_Rank>();
            UserProductComments = new List<Product_Comment>();
            UserProductRanks = new List<Product_Rank>();
        }

        public virtual IList<ProductsBought> ProductsBought { get; set; }
        public virtual IList<Shopping_Cart_Day> Shopping_Cart_Days { get; set; }
        //public virtual IList<Shopping_Cart_Week> Shopping_Cart_Weeks { get; set; }
        //public virtual IList<Shopping_Cart_Month> Shopping_Cart_Months { get; set; }
        //public virtual IList<Shopping_Cart_Year> Shopping_Cart_Years { get; set; }
        public virtual IList<Shopping_Cart_LookFor> Shopping_Cart_LookFor { get; set; }
        public virtual IList<Shop_Comment> UserShopComments { get; set; }
        public virtual IList<Shop_Rank> UserShopRanks { get; set; }

        public virtual IList<Product_Comment> UserProductComments { get; set; }
        public virtual IList<Product_Rank> UserProductRanks { get; set; }



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
            //Location = new Location();

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

        public Product_Price(double Price, bool SpecialOffer = false, string SpecialOffer_Description = "")
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
    public class Company
    {
        public Company()
        {
            Products = new List<Product>();
        }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual List<Product> Products { get; set; }
    }
    public class Product
    {


        public Product(Product product)
        {

            this.ProductId = product.ProductId;
            this.Name = product.Name;
            this.Description = product.Description;
            this.Weight = product.Weight;
            this.Height = product.Height;
            this.Picture = product.Picture;
            this.Comments = product.Comments;
            this.Ranks = product.Ranks;
            this.ProductCategory = product.ProductCategory;
            this.Product_Code = product.Product_Code;
            //this.Shopping_Cart_DayId = product.Shopping_Cart_DayId;
            //this.shopping_Cart_Day = product.shopping_Cart_Day;
            //this.Shopping_Cart_WeekId = product.Shopping_Cart_WeekId;
            //this.shopping_Cart_Week = product.shopping_Cart_Week;
            this.ShopId = product.ShopId;
            this.Shop = product.Shop;
            this.Product_PriceId = product.Product_PriceId;
            this.Product_Price = product.Product_Price;


        }



        public Product()
        {
            Comments = new List<Product_Comment>();
            Ranks = new List<Product_Rank>();
            ProductCategory = new List<ProductCategory>();
            ProductShopping_Cart_Days = new List<ProductShopping_Cart_Day>();
            //ProductShopping_Cart_Weeks = new List<ProductShopping_Cart_Week>();
            //ProductShopping_Cart_Months = new List<ProductShopping_Cart_Month>();
            //ProductShopping_Cart_Years = new List<ProductShopping_Cart_Year>();
            ProductShopping_Cart_LookFor = new List<ProductShopping_Cart_LookFor>();
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

        //public virtual Product_Code Product_Code { get; set; }

        public int? Product_CodeId { get; set; }
        public virtual Product_Code Product_Code { get; set; }


        //public int? Shopping_Cart_DayId { get; set; }//
        //public Shopping_Cart_Day shopping_Cart_Day;

        //public int? Shopping_Cart_WeekId { get; set; }//
        //public Shopping_Cart_Week shopping_Cart_Week;

        public int? CompanyId { get; set; }//
        public virtual Company Company { get; set; }
        public int? ShopId { get; set; }//
        public virtual Shop Shop { get; set; }

        public int? Product_PriceId { get; set; }//
        public virtual Product_Price Product_Price { get; set; }

        public virtual IList<ProductShopping_Cart_Day> ProductShopping_Cart_Days { get; set; }
        //public virtual IList<ProductShopping_Cart_Week> ProductShopping_Cart_Weeks { get; set; }
        //public virtual IList<ProductShopping_Cart_Month> ProductShopping_Cart_Months { get; set; }
        //public virtual IList<ProductShopping_Cart_Year> ProductShopping_Cart_Years { get; set; }
        public virtual IList<ProductShopping_Cart_LookFor> ProductShopping_Cart_LookFor { get; set; }


    }
    public class ProductShopping_Cart_Day
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Shopping_Cart_DayId { get; set; }
        public virtual Shopping_Cart_Day Shopping_Cart_Day { get; set; }

    }

    public class ProductShopping_Cart_LookFor
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Shopping_Cart_LookForId { get; set; }
        public virtual Shopping_Cart_LookFor Shopping_Cart_LookFor { get; set; }

    }
    public class Location
    {


        public Location()
        {
            Country = "Polska";
            //Shop = new Shop();
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

        public virtual NetTopologySuite.Geometries.Point location { get; set; }
        public string SecondNumber { get; set; }
        public virtual Shop Shop { get; set; }
        public int? ShopLocationId { get; set; }
    }

    public class Shopping_Cart_Day
    {
        public Shopping_Cart_Day()
        {

            ProductShopping_Cart_Days = new List<ProductShopping_Cart_Day>();
        }

        public int Shopping_Cart_DayId { get; set; }
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string? DayUserId { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }


        //public virtual CartStatistics Statistic { get; set; }
        public virtual IList<ProductShopping_Cart_Day> ProductShopping_Cart_Days { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }



    }

    public class Shopping_Cart_LookFor
    {

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Shopping_Cart_LookFor()
        {
            //Products = new List<Product>();
            ProductShopping_Cart_LookFor = new List<ProductShopping_Cart_LookFor>();
        }

        public int Shopping_Cart_LookForId { get; set; }
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        //public virtual List<Product> Products { get; set; }

        public string? LookForUserId { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }


        public virtual IList<ProductShopping_Cart_LookFor> ProductShopping_Cart_LookFor { get; set; }
        //public virtual CartStatistics Statistic { get; set; }
    }
    public class Product_Code
    {

        public Product_Code()
        {
            //Product = new Product();
            Products = new List<Product>();
        }
        public int Product_CodeId { get; set; }
        public string Code { get; set; }
        public string CodeType { get; set; }
        public string Country { get; set; }
        public string Producer { get; set; }

        public string ProductInfo { get; set; }
        public virtual List<Product> Products { get; set; }

        //public int? ProductCodeId { get; set; }//
        //public virtual Product Product { get; set; }
    }
    public class Product_Rank
    {
        public int Product_RankId { get; set; }
        public int Rank { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public class Shop_Rank
    {
        public int Shop_RankId { get; set; }
        public int Rank { get; set; }


        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

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

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
    public class Product_Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }


}

