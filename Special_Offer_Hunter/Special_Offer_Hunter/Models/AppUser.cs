using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Shopping_Cart_Day = new List<Shopping_Cart_Day>();
            Shopping_Cart_Week = new List<Shopping_Cart_Week>();

        }

        public IList<Shopping_Cart_Day> Shopping_Cart_Day { get; set; }
        public IList<Shopping_Cart_Week> Shopping_Cart_Week { get; set; }


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

        public  IList<Shop_Comment> Comments { get; set; }
        public IList<Shop_Rank> Ranks { get; set; }
        public IList<Product> Products { get; set; }
        public Location Location { get; set; }
       

    }

    public class Product
    {

        public Product()
        {
            Comments = new List<Product_Comment>();
            Ranks = new List<Product_Rank>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }

        public IList<Product_Comment> Comments { get; set; }
        public IList<Product_Rank> Ranks { get; set; }
        public Product_Code Product_Code { get; set; }

        public int Shopping_Cart_DayId { get; set; }
        public Shopping_Cart_Day shopping_Cart_Day;

        public int Shopping_Cart_WeekId { get; set; }
        public Shopping_Cart_Week shopping_Cart_Week;

        public int ShopId { get; set; }
        public Shop Shop { get; set; }

    }


    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public Shop Shop { get; set; }
        public int ShopLocationId { get; set; } 
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
        public ApplicationUser User { get; set; }

        public IList<Product> Products { get; set; }
    }


    public class Shopping_Cart_Week
    {

        public Shopping_Cart_Week()
        {

        }

        public int Shopping_Cart_WeekId { get; set; }
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class Product_Code
    {
        public int Product_CodeId { get; set; }
        public string Name { get; set; }

        public int ProductCodeId{get;set;}
        public Product Product { get; set; }
    }

    public class Product_Rank
    {
        public int Product_RankId { get; set; }
        public string Name { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class Shop_Rank
    {
        public int Shop_RankId { get; set; }
        public string Name { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }


    public class Shop_Comment
    {
        public int Shop_CommentId { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }

    }

    public class Product_Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }




   
}

