﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class ProductLocation
    {
        public Product product { get; set; }
        public Location location { get; set; }
        public Shop shop { get; set; }
    }
}
