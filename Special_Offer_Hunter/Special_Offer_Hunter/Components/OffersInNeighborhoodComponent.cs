using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Components
{
    public class OffersInNeighborhoodComponent:ViewComponent
    {
        private IRepository repository;
        IHttpContextAccessor httpContextAccessor;

        public OffersInNeighborhoodComponent(IRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            repository = repo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            string UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            SpecialOfferViewModel model = new SpecialOfferViewModel();
            model.CategoryName = "Napoje";
            model.ShopName = "Alex";
            model.PriceValue = 3;
            model.priceDescription = PriceDescription.Higher;
            model.MyLocation = repository.GetUserLocation(UserId);
            model.Distance = 5;

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
            model.list = list;
            
            return View("OffersInNeighborhoodComponent",model);
        }




    }
}
