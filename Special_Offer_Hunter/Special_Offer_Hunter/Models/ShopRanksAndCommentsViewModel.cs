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
            shopRank = 3;
            shopComments = 112;
            AddComment = new Shop_Comment();
            AddRank = new Shop_Rank();
        }



        public int shopRank { get; set; }
        public int shopComments { get; set; }

        public List<Shop_Comment> listOfComments { get; set; }

        public Shop_Comment AddComment { get; set; }
        public Shop_Rank AddRank { get; set; }




    }
}
