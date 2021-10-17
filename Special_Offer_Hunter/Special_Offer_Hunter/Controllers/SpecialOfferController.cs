using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Special_Offer_Hunter.Controllers
{
    [Authorize]
    public class SpecialOfferController : Controller
    {
        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;
        public SpecialOfferController(IRepository repo, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
        {
            repository = repo;

            if (GetUser == null)
            {
                string UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                this.GetUser = () => UserId;

            }
            else
            {
                this.GetUser = GetUser;
            }
        }


        public PartialViewResult OffersInNeighborhood(SpecialOfferViewModel modelX)
        {
            string UserId = GetUser();
            List<string> list2 = repository.GetCategories();
            modelX.CategoryList = new SelectList(list2.ToList());

            modelX.MyLocation = repository.GetUserLocation(UserId);


            SingleSort sorting1 = new SortNone();
            SingleSort sorting2 = new SortByProductName();
            SingleSort sorting3 = new SortByShopName();
            SingleSort sorting4 = new SortByPriceValue();
            SingleSort sorting5 = new SortByDistance();

            sorting1.SetNextSortObject(sorting2);
            sorting2.SetNextSortObject(sorting3);
            sorting3.SetNextSortObject(sorting4);
            sorting4.SetNextSortObject(sorting5);


            SingleSearch sort0 = new SearchShopName();
            SingleSearch sort1 = new SearchCategoryName();
            SingleSearch sort2 = new SearchCategoryBarCode();
            SingleSearch sort3 = new SearchCategoryBySpecialOffer();
            SingleSearch sort4 = new SearchProductName();
            SingleSearch sort5 = new SearchPriceValue();

            sort0.SetNextSortObject(sort1);
            sort1.SetNextSortObject(sort2);
            sort2.SetNextSortObject(sort3);
            sort3.SetNextSortObject(sort4);
            sort4.SetNextSortObject(sort5);


            sort0.SetSorting(modelX);
            sorting1.SetSorting(modelX);

            Dictionary<Product, double> list = repository.GetProductsWithSpecialOffer(modelX);
            modelX.list2 = list;

            return PartialView("OffersInNeighborhood", modelX);

        }
    }
}
