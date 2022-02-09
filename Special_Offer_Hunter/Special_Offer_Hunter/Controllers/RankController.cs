using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Special_Offer_Hunter.Models;
using System;
using System.Security.Claims;

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



        [HttpGet]
        public PartialViewResult ShopRankPanel(string ShopId)
        {
            string UserId = GetUser();
            int Id = Int32.Parse(ShopId);
            ShopRanksAndCommentsViewModel model = repository.GetRankAndCommentShopViewModel(Id, UserId);
            return PartialView("RankAndComment", model);
        }


        [HttpPost]
        public PartialViewResult AddRank(Shop_Rank data)
        {
            string UserId = GetUser();
            Shop_Rank r = repository.AddRankToShop(UserId, data);

            ShopRanksAndCommentsViewModel model = repository.GetRankAndCommentShopViewModel(data.ShopId, UserId);

            return PartialView("RankAndComment", model);
        }


        [HttpPost]
        public PartialViewResult AddComment(Shop_Comment data)
        {
            string UserId = GetUser();
            Shop_Comment c = repository.AddCommentToShop(UserId, data);
            ShopRanksAndCommentsViewModel model = repository.GetRankAndCommentShopViewModel(data.ShopId, UserId);
            return PartialView("RankAndComment", model);
        }

        [HttpGet]
        public PartialViewResult ProductRankPanel(string ProductId)
        {
            string UserId = GetUser();
            int Id = Int32.Parse(ProductId);
            ProductRanksAndCommentsViewModel model = repository.GetRankAndCommentProductViewModel(Id, UserId);
            return PartialView("RankAndCommentProduct", model);
        }

        [HttpPost]
        public PartialViewResult AddRankProduct(Product_Rank data)
        {
            string UserId = GetUser();
            Product_Rank r = repository.AddRankToProduct(UserId, data);

            ProductRanksAndCommentsViewModel model = repository.GetRankAndCommentProductViewModel(data.ProductId, UserId);

            return PartialView("RankAndCommentProduct", model);
        }


        [HttpPost]
        public PartialViewResult AddCommentProduct(Product_Comment data)
        {
            string UserId = GetUser();
            Product_Comment c = repository.AddCommentToProduct(UserId, data);
            ProductRanksAndCommentsViewModel model = repository.GetRankAndCommentProductViewModel(data.ProductId, UserId);
            return PartialView("RankAndCommentProduct", model);
        }


        public PartialViewResult GetUserRank(int HowMany = 20)
        {
            string UserId = GetUser();

            UserRankViewModel model = repository.GetUsersRank(HowMany);



            return PartialView("GetUserRank", model);
        }


    }
}
