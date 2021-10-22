using System;
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

        public async Task<IActionResult> ShowShoppingCartProductsOnMap(ShoppingCartType shoppingCartType = ShoppingCartType.Dzień)
        {
            string UserId = GetUser();
            ProductLocationViewModel model = new ProductLocationViewModel();
            model.list = repository.GetProductLocationByCartType(shoppingCartType, UserId);
            model.shoppingcartType = shoppingCartType;
            model.UserLocation = repository.GetUserLocation(UserId);


            var httpClient1 = new HttpClient();
            var url1 = "https://api.tomtom.com/routing/1/calculateRoute/53.4098804154932%2C18.4514923905208105655635714446%2C%2018.437029559206%3A53.41290973979078%2C18.45185/json?avoid=unpavedRoads&key=YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";
            HttpResponseMessage response1 = await httpClient1.GetAsync(url1);
            string responseBody1 = await response1.Content.ReadAsStringAsync();
            JObject reverseGeocodingObj = JObject.Parse(responseBody1);

            //string postCode = (string)reverseGeocodingObj["address"]["postcode"];




            return View(model);
        }
    }
}
