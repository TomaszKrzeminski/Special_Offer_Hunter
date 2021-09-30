using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;

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
          
           
            modelX.MyLocation = repository.GetUserLocation(UserId);
           

            SingleSearch sort1 = new SearchShopName();
            SingleSearch sort2 = new SearchCategoryName();
            SingleSearch sort3 = new SearchProductName();
            SingleSearch sort4 = new SearchPriceValue();



            sort1.SetNextSortObject(sort2);
            sort2.SetNextSortObject(sort3);
            sort3.SetNextSortObject(sort4);


            sort1.SetSorting(modelX);


            Dictionary<Product, double> list = repository.GetProductsWithSpecialOffer(modelX);
            modelX.list2 = list;

            return PartialView( modelX);


            
        }
    }
}
