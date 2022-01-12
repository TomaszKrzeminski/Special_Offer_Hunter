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
            SpecialOffer = false;
            Category = "";
        }


        public string TextMessage { get; set; }
        public string CodeCountry { get; set; }

        [Required(ErrorMessage = "Uzupełnij nazwe")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij cenę")]
        [Range(1, int.MaxValue, ErrorMessage = "Cena musi być  większa od 0")]
        public double Price { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Uzupełnij wage")]
        [Range(1, int.MaxValue, ErrorMessage = "Waga musi być większa od zera")]
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

        public bool SpecialOffer { get; set; }

        public int ShopId { get; set; }



    }
}
