using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Special_Offer_Hunter.Models;

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
