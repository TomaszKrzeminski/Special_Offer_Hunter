using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using System;
using System.Security.Claims;

namespace Special_Offer_Hunter.Components
{
    public class RanksAndCommentsComponent : ViewComponent
    {

        private IRepository repository;
        IHttpContextAccessor httpContextAccessor;
        private Func<string> GetUser;

        public RanksAndCommentsComponent(IRepository repo, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
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

        public IViewComponentResult Invoke()
        {
            ShopRanksAndCommentsViewModel model = repository.GetRankAndCommentShopViewModel(1, "a399bc4f-4a4c-4bc1-ada2-23ca2a881e9d");

            return View(model);
        }





    }
}
