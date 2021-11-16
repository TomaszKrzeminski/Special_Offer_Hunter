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
        }

        public bool Rank { get; set; }
        public bool Comment { get; set; }


        public int ShopId { get; set; }

        public int shopRank { get; set; }
        public int shopComments { get; set; }

        public List<Shop_Comment> listOfComments { get; set; }

        public Shop_Comment AddComment { get; set; }
        public Shop_Rank AddRank { get; set; }




    }
}
