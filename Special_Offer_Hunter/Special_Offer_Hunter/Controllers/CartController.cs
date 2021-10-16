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
    public class CartController : Controller
    {

        private readonly ILogger<CartController> _logger;
        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;

        public CartController(ILogger<CartController> logger, IRepository repo, UserManager<ApplicationUser> userMgr, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
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


        public PartialViewResult RemoveProductFromCart(RemoveProductFromCart model)
        {
            string UserId = GetUser();

            repository.RemoveProductFromShoppingCart(UserId, model.Type, model.ProductId);
            ShoppingCartViewModel viewModel = repository.GetShoppingCart(UserId, model.Type);
            return PartialView("AddProductToShoppingCart", viewModel);
        }

        [HttpGet]
        public PartialViewResult AddProductToShoppingCart(AddProcutToShoppingCart model)
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
