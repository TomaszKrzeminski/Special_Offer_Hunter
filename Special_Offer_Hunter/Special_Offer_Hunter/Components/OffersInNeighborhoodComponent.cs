﻿using Microsoft.AspNetCore.Http;
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
            model.ShopName = "";
            model.PriceValue = 3;
            model.priceDescription = PriceDescription.Wszystkie;
            model.MyLocation = repository.GetUserLocation(UserId);
            model.Distance = 50;

            SingleSearch sort1 = new SearchShopName();
            SingleSearch sort2 = new SearchCategoryName();
            SingleSearch sort3 = new SearchProductName();
            SingleSearch sort4 = new SearchPriceValue();



            sort1.SetNextSortObject(sort2);
            sort2.SetNextSortObject(sort3);
            sort3.SetNextSortObject(sort4);


            sort1.SetSorting(model);


            Dictionary<Product,double> list = repository.GetProductsWithSpecialOffer(model);
            model.list2 = list;
            
            return View("OffersInNeighborhoodComponent",model);
        }




    }
}
