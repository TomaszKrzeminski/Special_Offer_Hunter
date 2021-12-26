using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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





        public async Task<IActionResult> ReverseGeocodingAsync(string Latitude, string Longitude)
        {
            string ReverseGeocodingKey = "pk.6a0568ea2a60f5218a864c2d9f7e5432";
            //string ReverseGeocodingKey = configuration.GetValue<string>("ApiOpenWeather");
            var url1 = "https://us1.locationiq.com/v1/reverse.php?key=" + ReverseGeocodingKey + "&lat=" + Longitude + "&lon=" + Latitude + "&format=json";
            var httpClient1 = new HttpClient();
            HttpResponseMessage response1 = await httpClient1.GetAsync(url1);

            string responseBody1 = await response1.Content.ReadAsStringAsync();


            ShopLocationData locationData = new ShopLocationData();
            await locationData.GetLocation(Latitude, Longitude);
            AddShopViewModel model = new AddShopViewModel();
            model.SetLocation(locationData);
            return PartialView(model);
        }







        [HttpPost]
        public JsonResult AutoCompleteOwnerName(string prefix)
        {
            //var customers = repository.GetOwnerNames(prefix);

            var customers = repository.GetOwnerNames2(prefix);

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


            return PartialView("ShowShopOnMap", model);
        }








        //public IActionResult AddShop2()
        //{
        //    return View("AddShop2");
        //}


        public IActionResult AddShop()
        {
            AddShopViewModel model = new AddShopViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddShop(AddShopViewModel model)
        {

            bool check = false;
            check = repository.AddShop(model);

            if (!check)
            {
                return View("AddShop", model);
            }
            else
            {
                string Message = "Pomyślnie dodano nowy sklep " + model.shop.Name;
                return View("Error_1", Message);
            }



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
