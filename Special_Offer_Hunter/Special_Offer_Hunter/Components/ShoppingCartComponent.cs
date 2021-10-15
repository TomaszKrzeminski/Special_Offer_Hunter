using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Components
{
    public class ShoppingCartComponent : ViewComponent
    {

        private IRepository repository;
        IHttpContextAccessor httpContextAccessor;
        private Func<string> GetUser;

        public ShoppingCartComponent(IRepository repo, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
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

            return View("ShoppingCartComponent");
        }





    }
}
