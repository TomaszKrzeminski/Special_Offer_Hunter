namespace Special_Offer_Hunter.Models
{
    public class ManagementProductViewModel
    {


        public ManagementProductViewModel()
        {
            product = new Product();
            UserId = "";
            Name = "Dodaj nazwę";
            Description = "Opis ";
            Weight = 0;
            Height = 0;
            Picture = "ProductXXX.jpg";
            Shop = "Znajdz sklep";
            Code = "Kod kreskowy";
            Price = 0;
            Category = "Kategoria produktu";
        }



        public Product product { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public string Picture { get; set; }

        public string Shop { get; set; }

        public string Code { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }



    }
}
