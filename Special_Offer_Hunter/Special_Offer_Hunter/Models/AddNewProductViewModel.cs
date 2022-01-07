using Microsoft.AspNetCore.Mvc.Rendering;
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
            Weight = 0;

            Category = "";
        }

        [Required(ErrorMessage = "Uzupełnij nazwe")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij cenę")]
        public double Price { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Uzupełnij wage")]
        public double Weight { get; set; }
        //public double Height { get; set; }

        public string Picture { get; set; }


        public SelectList Categories { get; set; }

        [Required(ErrorMessage = "Wybierz kategorię ")]
        public string Category { get; set; }


        [Required(ErrorMessage = "Dodaj kod kreskowy ")]
        public string Barcode { get; set; }
        [Required(ErrorMessage = "Wybierz markę ")]
        public string Company { get; set; }

        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Wyszukaj sklep ")]
        public string Shop { get; set; }

        public int ShopId { get; set; }



    }
}
