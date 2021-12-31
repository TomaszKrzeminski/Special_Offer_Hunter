using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public class AddNewProductViewModel
    {


        public AddNewProductViewModel()
        {
            Name = "Dodaj nazwe";
            Price = 0;
            Description = "Jakiś opis";
            Weight = 10;
            Height = 20;
        }
       
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }

        public string Picture { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public string Barcode { get; set; }

        public string Company { get; set; }

        public int CompanyId { get; set; }

        public string Shop { get; set; }     
        
        public int ShopId { get; set; }
                      

       
    }
}
