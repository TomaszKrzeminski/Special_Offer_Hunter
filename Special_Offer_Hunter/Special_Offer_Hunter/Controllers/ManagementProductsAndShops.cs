using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Special_Offer_Hunter.Controllers
{
    public class ManagementProductsAndShops : Controller
    {

        public IActionResult ManagementProductPanel()
        {
            return View();
        }

        public IActionResult ManagementShopPanel()
        {
            return View();
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
