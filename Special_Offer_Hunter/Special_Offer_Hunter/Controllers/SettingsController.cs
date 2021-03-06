using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using System;
using System.Security.Claims;

namespace Special_Offer_Hunter.Controllers
{
    public class SettingsController : Controller
    {

        private IRepository repository;
        private Func<string> GetUser;
        IHttpContextAccessor httpContextAccessor;
        IHostingEnvironment _environment;
        public SettingsController(IHostingEnvironment _environment, IRepository repo, IHttpContextAccessor httpContextAccessor, Func<string> GetUser = null)
        {
            this._environment = _environment;
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








    }
}
