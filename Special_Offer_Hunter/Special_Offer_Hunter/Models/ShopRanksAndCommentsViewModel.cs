using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class ShopRanksAndCommentsViewModel
    {
        public ShopRanksAndCommentsViewModel()
        {
            listOfComments = new List<Shop_Comment>();
            shopRank = 0;
            shopComments = 0;
            AddComment = new Shop_Comment();
            AddRank = new Shop_Rank();
            ShopId = 0;
            Rank = false;
            Comment = false;
            ShopName = "";
            UserImage = "unnamed.jpg";
        }

        public string ShopName { get; set; }
        public bool Rank { get; set; }
        public bool Comment { get; set; }


        public int ShopId { get; set; }

        public int shopRank { get; set; }
        public int shopComments { get; set; }

        public List<Shop_Comment> listOfComments { get; set; }

        public Shop_Comment AddComment { get; set; }
        public Shop_Rank AddRank { get; set; }

        public string UserImage { get; set; }



    }

    public class ProductRanksAndCommentsViewModel
    {
        public ProductRanksAndCommentsViewModel()
        {
            listOfComments = new List<Product_Comment>();
            productRank = 0;
            productComments = 0;
            AddComment = new Product_Comment();
            AddRank = new Product_Rank();
            ProductId = 0;
            Rank = false;
            Comment = false;
            ProductName = "";
            UserImage = "unnamed.jpg";
        }

        public string ProductName { get; set; }
        public bool Rank { get; set; }
        public bool Comment { get; set; }


        public int ProductId { get; set; }

        public int productRank { get; set; }
        public int productComments { get; set; }

        public string UserImage { get; set; }
        public List<Product_Comment> listOfComments { get; set; }

        public Product_Comment AddComment { get; set; }
        public Product_Rank AddRank { get; set; }




    }






}
