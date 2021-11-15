using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Controllers
{
    public class RankController : Controller
    {

        private readonly ILogger<CartController> _logger;
        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;

        public RankController(ILogger<CartController> logger, IRepository repo, UserManager<ApplicationUser> userMgr, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
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




        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public PartialViewResult AddRank(Shop_Rank data)
        {
            string UserId = GetUser();
            Shop_Rank r = repository.AddRankToShop(UserId, data);

            ShopRanksAndCommentsViewModel model = new ShopRanksAndCommentsViewModel();

            return PartialView("RankAndComment", model);
        }


        [HttpPost]
        public PartialViewResult AddComment(Shop_Comment data)
        {
            string UserId = GetUser();
            Shop_Comment c = repository.AddCommentToShop(UserId, data);
            ShopRanksAndCommentsViewModel model = new ShopRanksAndCommentsViewModel();
            return PartialView("RankAndComment", model);
        }



    }
}
