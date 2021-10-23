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

namespace Special_Offer_Hunter.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IRepository repo, UserManager<ApplicationUser> userMgr, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
        {
            _logger = logger;
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


        public async Task<IActionResult> Test(ShoppingCartType shoppingCartType = ShoppingCartType.Dzień)
        {
            string UserId = GetUser();
            ProductLocationViewModel model = new ProductLocationViewModel();
            model.list = repository.GetProductLocationByCartType(shoppingCartType, UserId);
            model.shoppingcartType = shoppingCartType;
            model.UserLocation = repository.GetUserLocation(UserId);


            Location location = repository.GetUserLocation(UserId);
            ViewData["MyPositionLat"] = location.Latitude.ToString().Replace(',', '.');
            ViewData["MyPositionLon"] = location.Longitude.ToString().Replace(',', '.'); ;


            List<Places> listPlaces = MakeLocationString2(model.list);
            model.listPlaces = listPlaces;
            var json = System.Text.Json.JsonSerializer.Serialize(listPlaces);

            model.JsonShops = json;

            string Locations = MakeLocationString(model.list);
            ViewData["MyTomTomKey"] = "YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";


            //string Locations = "53.41103498175408,18.45158868969927:53.406483951579744,18.44005073339871:53.40562466207876,18.436765808096027:53.40727282604525,18.433821043930354";

            //var httpClient1 = new HttpClient();
            ////var url1 = "https://api.tomtom.com/routing/1/calculateRoute/52.50931%2C13.42936%3A52.50274%2C13.43872/json?avoid=unpavedRoads&key=YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";
            //var url1 = "https://api.tomtom.com/routing/1/calculateRoute/" + Locations + "/json?avoid=unpavedRoads&key=YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";
            //HttpResponseMessage response1 = await httpClient1.GetAsync(url1);
            //string responseBody1 = await response1.Content.ReadAsStringAsync();

            //var root = JsonConvert.DeserializeObject<Root>(responseBody1);




            return View(model);
        }




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
            //string userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            repository.SaveCoordinatesAppUser(getValue(Latitude), getValue(Longitude), userId);
        }

    }
}
