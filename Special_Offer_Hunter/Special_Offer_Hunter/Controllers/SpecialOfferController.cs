using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Controllers
{
    [Authorize]
    public class SpecialOfferController : Controller
    {
        private IRepository repository;
        public SpecialOfferController(IRepository repo)
        {
            repository = repo;
        }


        public PartialViewResult OffersInNeighborhood()
        {
            SpecialOfferViewModel model = new SpecialOfferViewModel();
            model.CategoryName = "Napoje";
            model.ShopName = "Alex";
            model.PriceValue = 3;
            model.priceDescription = PriceDescription.Higher;
            //model.MyLocation = repository.GetUserLocation();

            SingleSort sort1 = new SortDistance();
            SingleSort sort2 = new SortShopName();
            SingleSort sort3 = new SortCategoryName();
            SingleSort sort4 = new SortProductName();
            SingleSort sort5 = new SortPriceValue();


            sort1.SetNextSortObject(sort2);
            sort2.SetNextSortObject(sort3);
            sort3.SetNextSortObject(sort4);
            sort4.SetNextSortObject(sort5);

            sort1.SetSorting(model);


            List<Product> list = repository.GetProductsWithSpecialOffer(model);

             return  PartialView(model);
        }
    }
}
