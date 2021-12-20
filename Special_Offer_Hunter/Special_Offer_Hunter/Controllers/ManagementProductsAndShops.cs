using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Controllers
{
    public class ManagementProductsAndShops : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;
        IHostingEnvironment _environment;


        public ManagementProductsAndShops(ILogger<HomeController> logger, IHostingEnvironment env, IRepository repo, UserManager<ApplicationUser> userMgr, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
        {
            _logger = logger;
            repository = repo;
            _environment = env;
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

        [HttpPost]
        public JsonResult AutoCompleteShopName(string prefix)
        {
            var shops = repository.GetShopNames(prefix);

            //var jsonResult = shops.Select(x => new { text = x });

            return Json(shops);
        }


        [HttpPost]
        public JsonResult AutoCompleteOwnerName(string prefix)
        {
            var customers = repository.GetOwnerNames(prefix);

            //var jsonResult = customers.Select(x => new { text = x });

            return Json(customers);
        }



        public async Task<PartialViewResult> ShowShopOnMap()
        {
            string UserId = GetUser();
            ShopLocationViewModel model = new ShopLocationViewModel();

            model.UserLocation = repository.GetUserLocation(UserId);


            Location location = repository.GetUserLocation(UserId);
            ViewData["MyPositionLat"] = location.Latitude.ToString().Replace(',', '.');
            ViewData["MyPositionLon"] = location.Longitude.ToString().Replace(',', '.'); ;

            ViewData["MyTomTomKey"] = "YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";

            /////




            //var httpClient1 = new HttpClient();

            //string LocationsX = MakeLocationStringX(model.UserLocation, model.list);

            //var url1 = "https://api.tomtom.com/routing/1/calculateRoute/" + LocationsX + "/json?avoid=unpavedRoads&key=YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O&routeType=fastest";
            //HttpResponseMessage response1 = await httpClient1.GetAsync(url1);
            //string responseBody1 = await response1.Content.ReadAsStringAsync();

            //Root root = JsonConvert.DeserializeObject<Root>(responseBody1);

            //model.Distance = model.SetDistance(root);
            //model.Time = model.SetTimeMinutes(root);
            //model.ArrivalTime = model.SetTimeArrival(root);          ////


            return PartialView("ShowShopOnMap", model);
        }








        public IActionResult AddShop2()
        {
            return View("AddShop2");
        }


        public IActionResult AddShop()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult RemoveShop()
        {
            return View();
        }

        public IActionResult RemoveProduct()
        {
            return View();
        }

        public IActionResult ChangeShop()
        {
            return View();
        }

        public IActionResult ChangeProduct()
        {
            return View();
        }

    }
}
