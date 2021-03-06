using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Special_Offer_Hunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Controllers
{
    public class ManagementProductsAndShopsController : Controller
    {
        private readonly ILogger<ManagementProductsAndShopsController> _logger;
        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;
        IHostingEnvironment _environment;


        public ManagementProductsAndShopsController(ILogger<ManagementProductsAndShopsController> logger, IHostingEnvironment env, IRepository repo, UserManager<ApplicationUser> userMgr, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
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
        public JsonResult AutoCompleteCompany(string prefix)
        {
            var companies = repository.GetCompanyNamesAutocomplete(prefix);



            return Json(companies);
        }


        [HttpPost]
        public JsonResult AutoCompleteShop1(string prefix)
        {
            var shops = repository.GetShopNamesAutocomplete(prefix);

            //var jsonResult = shops.Select(x => new { text = x });

            return Json(shops);
        }


        [HttpPost]
        public JsonResult AutoCompleteShopName(string prefix)
        {
            var shops = repository.GetShopNames(prefix);



            return Json(shops);
        }


        [HttpPost]
        public JsonResult AutoCompleteShop(string prefix)
        {
            var shops = repository.GetShopNamesAutocomplete(prefix);


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
        public IActionResult AddShop()
        {
            string UserId = GetUser();
            ApplicationUserData user = repository.GetUserData2(UserId);
            AddShopViewModel model = new AddShopViewModel();
            model.userData = user;

            return View("AddShop3", model);
        }

        [HttpPost]
        public IActionResult AddShop(AddShopViewModel model)
        {

            bool check = false;

            if (model.shop.Name == null || model.shop.Name == "")
            {
                ModelState.AddModelError("shop.Name", "Uzupełnij nazwę sklepu");
            }

            //if (model.shop.ApplicationUser.UserName == null || model.shop.ApplicationUser.UserName == "")
            //{
            //    ModelState.AddModelError("shop.ApplicationUser.UserName", "Wyszukaj właściciela");
            //}

            if (ModelState.IsValid)
            {
                check = repository.AddShop2(model);

                if (!check)
                {

                    return View("AddShop3", model);
                }
                else
                {
                    string Message = "Pomyślnie dodano nowy sklep " + model.shop.Name;
                    return View("Error_1", Message);
                }

            }
            else
            {
                return View("AddShop3", model);
            }








        }

        SelectList GetProductCategories()
        {
            List<string> list2 = repository.GetCategories();
            SelectList list = new SelectList(list2.ToList());
            return list;
        }

        public IActionResult AddProduct()
        {
            AddNewProductViewModel model = new AddNewProductViewModel();
            model.Categories = GetProductCategories();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProduct(AddNewProductViewModel model)
        {
            string UserId = GetUser();
            model.UserId = UserId;

            model.Categories = GetProductCategories();
            if (ModelState.IsValid)
            {

                string message = repository.CheckIfNewProductExists2(model.Barcode, model.ShopId, model.Price);



                if (message == "")
                {
                    bool check = repository.AddProduct2(model);
                    if (!check)
                    {
                        return View("AddProduct", model);
                    }
                    else
                    {
                        model.TextMessage = "Pomyślnie dodano nowy produkt ";
                        return View("ShowProduct", model);
                    }
                }
                else
                {
                    return View("Error_1", message);
                }


            }
            else
            {
                return View("AddProduct", model);
            }

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
