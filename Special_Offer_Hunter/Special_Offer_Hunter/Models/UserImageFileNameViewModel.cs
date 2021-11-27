using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class UserImageFileNameViewModel
    {
        public UserImageFileNameViewModel(string name)
        {
            FileName = name;
        }
        public string FileName { get; set; }
    }
}
