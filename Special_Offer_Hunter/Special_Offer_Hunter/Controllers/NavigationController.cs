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
using NetTopologySuite.Index.Bintree;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Special_Offer_Hunter.Models;
using Special_Offer_Hunter.Models2;

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



        public async Task<PartialViewResult> ShowShoppingCartProductsOnMap(ShoppingCartType shoppingCartType = ShoppingCartType.Rok)
        {
            string UserId = GetUser();
            ProductLocationViewModel model = new ProductLocationViewModel();
            model.list = repository.GetProductLocationByCartType(shoppingCartType, UserId);
            model.shoppingcartType = shoppingCartType;
            model.UserLocation = repository.GetUserLocation(UserId);


            Location location = repository.GetUserLocation(UserId);
            ViewData["MyPositionLat"] = location.Latitude.ToString().Replace(',', '.');
            ViewData["MyPositionLon"] = location.Longitude.ToString().Replace(',', '.'); ;




            List<Places> listPlaces = new List<Places>();
            Places p1 = new Places();
            p1.id = 0;
            p1.name = "Moja Pozycja";
            p1.center = new List<string>() { location.Latitude.ToString().Replace(',', '.'), location.Longitude.ToString().Replace(',', '.') };
            listPlaces.Add(p1);
            listPlaces.AddRange(MakeLocationString(model.list));
            model.listPlaces = listPlaces;
            var json = System.Text.Json.JsonSerializer.Serialize(listPlaces);

            model.JsonShops = json;






            ViewData["MyTomTomKey"] = "YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O";

            /////




            var httpClient1 = new HttpClient();

            string LocationsX = MakeLocationStringX(model.UserLocation, model.list);

            var url1 = "https://api.tomtom.com/routing/1/calculateRoute/" + LocationsX + "/json?avoid=unpavedRoads&key=YKCJ1ZeW4GdxXOmONZi4UoSKOKpOTT4O&routeType=fastest";
            HttpResponseMessage response1 = await httpClient1.GetAsync(url1);
            string responseBody1 = await response1.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<Root>(responseBody1);

            ////




            return PartialView(model);
        }
    }
}
