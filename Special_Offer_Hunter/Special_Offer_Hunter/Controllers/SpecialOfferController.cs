using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Controllers
{
    public class SpecialOfferController : Controller
    {
        private IRepository repository;
        public SpecialOfferController(IRepository repo)
        {
            repository = repo;
        }


        public IActionResult OffersInNeighborhood()
        {
            SpecialOfferViewModel model = new SpecialOfferViewModel();
            model.Category = "Napoje";
            
            List<Product> list = repository.GetProductsWithSpecialOffer(model);

            return PartialView();
        }
    }
}
