using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Controllers
{
    public class StatisticsController : Controller
    {
        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;
        public StatisticsController(IRepository repo, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
        {
            repository = repo;

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
        public PartialViewResult ChangeNumberOfProducts(AddProcutToShoppingCart model)
        {
            string UserId = GetUser();


            if (model.ProductId > 0)
            {
                bool check = repository.AddProductToUserShoppingCart(UserId, model.Type, model.ProductId);
            }

            ShoppingCartViewModel viewModel = repository.GetShoppingCart(UserId, model.Type);

            return PartialView("AddProductToShoppingCart", viewModel);
        }



    }
}
