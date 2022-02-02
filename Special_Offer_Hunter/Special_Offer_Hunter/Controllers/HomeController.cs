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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Special_Offer_Hunter.Models;
using Special_Offer_Hunter.Models2;
using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Special_Offer_Hunter.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;
        IHostingEnvironment _environment;


        public HomeController(ILogger<HomeController> logger, IHostingEnvironment env, IRepository repo, UserManager<ApplicationUser> userMgr, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
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
        public JsonResult AutoCompleteShopShort(string prefix)
        {
            prefix = prefix.ToUpper();
            var shops = repository.GetShopNamesAutocompleteShort(prefix);
            return Json(shops);
        }


        [HttpPost]
        public JsonResult AutoCompleteProductNameShort(string prefix)
        {
            var names = repository.AutoCompleteProductName(prefix);
            return Json(names);
        }


        List<Places> MakeLocationString2(List<ProductLocation> list)
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


        [HttpGet]
        public IActionResult GetPicture(string id)
        {



            try
            {
                string UserId = GetUser();
                var uploads = Path.Combine(_environment.ContentRootPath, "UserImageDefault");
                var text = Path.Combine(uploads, "unnamed.jpg");
                var image = System.IO.File.OpenRead(text);

                if (repository.CheckPictureOwner("/Home/GetPicture/" + id, UserId))
                {
                    uploads = Path.Combine(_environment.ContentRootPath, "UserImages");
                    text = Path.Combine(uploads, id);
                    image = System.IO.File.OpenRead(text);
                }

                return File(image, "image/jpeg");
            }
            catch (Exception ex)
            {

                var uploads = Path.Combine(_environment.ContentRootPath, "UserImageDefault");
                var text = Path.Combine(uploads, "unnamed.jpg");
                var image = System.IO.File.OpenRead(text);

                return File(image, "image/jpeg");
            }

        }


        [HttpGet]
        public IActionResult GetUserPicturePatch(string Path)
        {

            int pFrom = Path.IndexOf("/Home");
            int pTo = Path.LastIndexOf(".jpg");



            String result = Path.Substring(pFrom, (pTo - pFrom) + 4);
            if (result != null)
            {
                return PartialView("GetUserPicturePatch", result);
            }
            else
            {
                return PartialView("GetUserPicturePatch", "");
            }


        }

        string MakeLocationString(List<ProductLocation> list)
        {
            string text = "";

            if (list.Count > 0)
            {
                foreach (var l in list)
                {
                    string s1 = l.location.Latitude.ToString();
                    s1 = s1.Replace(",", ".");

                    string s2 = l.location.Longitude.ToString();
                    s2 = s2.Replace(",", ".");
                    text += s1 + "," + s2 + ":";
                }

                text = text.Remove(text.Length - 1);
            }

            return text;

        }
        public string MakeLocationStringX(Location locationX, List<ProductLocation> list)
        {
            string Locations = locationX.Latitude.ToString().Replace(',', '.') + "," + locationX.Longitude.ToString().Replace(',', '.') + ":";

            foreach (var l in list)
            {

                string lat = l.location.Latitude.ToString().Replace(',', '.');
                string lon = l.location.Longitude.ToString().Replace(',', '.');

                Locations += lat + "," + lon + ":";

            }

            Locations = Locations.Remove(Locations.Length - 1, 1);


            return Locations;
        }

        //public async Task<IActionResult> Test(ShoppingCartType shoppingCartType = ShoppingCartType.Dzień)
        //{
        //    string UserId = GetUser();
        //    ProductLocationViewModel model = new ProductLocationViewModel();
        //    model.list = repository.GetProductLocationByCartType(shoppingCartType, UserId);
        //    model.shoppingcartType = shoppingCartType;
        //    model.UserLocation = repository.GetUserLocation(UserId);


        //    Location location = repository.GetUserLocation(UserId);
        //    ViewData["MyPositionLat"] = location.Latitude.ToString().Replace(',', '.');
        //    ViewData["MyPositionLon"] = location.Longitude.ToString().Replace(',', '.'); ;



        //    List<Places> listPlaces = MakeLocationString2(model.list);
        //    model.listPlaces = listPlaces;
        //    var json = System.Text.Json.JsonSerializer.Serialize(listPlaces);

        //    model.JsonShops = json;

        //    ViewData["MyTomTomKey"] = "YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";

        //    /////




        //    var httpClient1 = new HttpClient();

        //    string LocationsX = MakeLocationStringX(model.UserLocation, model.list);

        //    var url1 = "https://api.tomtom.com/routing/1/calculateRoute/" + LocationsX + "/json?avoid=unpavedRoads&key=YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O&routeType=fastest";
        //    HttpResponseMessage response1 = await httpClient1.GetAsync(url1);
        //    string responseBody1 = await response1.Content.ReadAsStringAsync();

        //    var root = JsonConvert.DeserializeObject<Root>(responseBody1);





        //    return View(model);
        //}

        //public async Task<IActionResult> Test2(ShoppingCartType shoppingCartType = ShoppingCartType.Rok)
        //{
        //    string UserId = GetUser();
        //    ProductLocationViewModel model = new ProductLocationViewModel();
        //    model.list = repository.GetProductLocationByCartType(shoppingCartType, UserId);
        //    model.shoppingcartType = shoppingCartType;
        //    model.UserLocation = repository.GetUserLocation(UserId);


        //    Location location = repository.GetUserLocation(UserId);
        //    ViewData["MyPositionLat"] = location.Latitude.ToString().Replace(',', '.');
        //    ViewData["MyPositionLon"] = location.Longitude.ToString().Replace(',', '.'); ;



        //    List<Places> listPlaces = MakeLocationString2(model.list);
        //    model.listPlaces = listPlaces;
        //    var json = System.Text.Json.JsonSerializer.Serialize(listPlaces);

        //    model.JsonShops = json;

        //    ViewData["MyTomTomKey"] = "YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";

        //    /////




        //    var httpClient1 = new HttpClient();

        //    string LocationsX = MakeLocationStringX(model.UserLocation, model.list);

        //    var url1 = "https://api.tomtom.com/routing/1/calculateRoute/" + LocationsX + "/json?avoid=unpavedRoads&key=YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O&routeType=fastest";
        //    HttpResponseMessage response1 = await httpClient1.GetAsync(url1);
        //    string responseBody1 = await response1.Content.ReadAsStringAsync();

        //    var root = JsonConvert.DeserializeObject<Root>(responseBody1);





        //    return View(model);
        //}


        public IActionResult Panel()
        {

            return View();
        }


        public double getValue(string value)
        {
            try
            {
                return double.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [HttpPost]
        public void ChangeCoordinates(string Longitude, string Latitude)
        {
            string userId = GetUser();
            bool check = repository.SaveCoordinatesAppUser(getValue(Latitude), getValue(Longitude), userId);
        }

    }
}
