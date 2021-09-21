using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Special_Offer_Hunter.Controllers
{
    public class RankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
