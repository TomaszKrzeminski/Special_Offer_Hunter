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
        public JsonResult AutoCompleteOwnerName(string prefix)
        {
            var customers = repository.GetShopNames(prefix);

            var jsonResult = customers.Select(x => new { text = x });

            return Json(customers);
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
