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
    public class ShoppingCartDetailsComponent : ViewComponent
    {
        private IRepository repository;
        IHttpContextAccessor httpContextAccessor;

        public ShoppingCartDetailsComponent(IRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            repository = repo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            ShoppingCartViewModel model = new ShoppingCartViewModel();

            return View("ShoppingCartDetailsComponent", model);
        }



    }
}
