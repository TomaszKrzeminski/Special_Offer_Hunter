using System.Collections.Generic;
using System.Linq;

namespace Special_Offer_Hunter.Models
{

    public class UserRank
    {

        public UserRank(string Email, string Name, string Surname, int Points)
        {
            this.Email = Email;
            this.Name = Name;
            this.Surname = Surname;
            this.Points = Points;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Points { get; set; }
    }


    public class UserRankViewModel
    {
        public UserRankViewModel()
        {
            RankList = new List<UserRank>();
        }


        public void Sort()
        {
            RankList.OrderBy(x => x.Points);
        }

        public List<UserRank> RankList { get; set; }

    }
}
