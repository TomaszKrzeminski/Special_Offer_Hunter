﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Controllers
{
    public class NavigationController : Controller
    {


        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;

        public NavigationController(IRepository repo, UserManager<ApplicationUser> userMgr, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
        {

            repository = repo;
            this.httpContextAccessor = httpContextAccessor;
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



        List<Places> MakeLocationString(List<ProductLocation> list)
        {
            List<Places> list2 = new List<Places>();

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    Places p = new Places();
                    p.id = i + 1;
                    p.name = list[i].shop.Name;
                    p.center = new List<string>() { list[i].location.Latitude.ToString().Replace(',', '.'), list[i].location.Longitude.ToString().Replace(',', '.') };
                    list2.Add(p);
                }


            }

            return list2;

        }


        public async Task<IActionResult> ShowShoppingCartProductsOnMap(ShoppingCartType shoppingCartType = ShoppingCartType.Rok)
        {
            string UserId = GetUser();
            ProductLocationViewModel model = new ProductLocationViewModel();
            model.list = repository.GetProductLocationByCartType(shoppingCartType, UserId);
            model.shoppingcartType = shoppingCartType;
            model.UserLocation = repository.GetUserLocation(UserId);


            Location location = repository.GetUserLocation(UserId);
            ViewData["MyPositionLat"] = location.Latitude.ToString().Replace(',', '.');
            ViewData["MyPositionLon"] = location.Longitude.ToString().Replace(',', '.'); ;



            List<Places> listPlaces = MakeLocationString(model.list);
            model.listPlaces = listPlaces;
            var json = System.Text.Json.JsonSerializer.Serialize(listPlaces);

            model.JsonShops = json;

            ViewData["MyTomTomKey"] = "YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";




            return View(model);
        }
    }
}
