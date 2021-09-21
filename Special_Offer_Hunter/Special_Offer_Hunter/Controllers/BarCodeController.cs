using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Special_Offer_Hunter.Controllers
{
    public class BarCodeController : Controller
    {
        public IActionResult ScanProductCode()
        {
            return View();
        }
        public IActionResult SearchByProductName()
        {
            return View();
        }
    }
}
