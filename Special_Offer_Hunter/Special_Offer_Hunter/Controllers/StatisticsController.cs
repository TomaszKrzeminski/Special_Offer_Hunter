using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Special_Offer_Hunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public PartialViewResult ChangeNumberOfProducts(ChangeProductNumber model)
        {
            string UserId = GetUser();


            if (model.ProductId > 0)
            {
                bool check = repository.ChangeNumberOfProducts(model.number, model.ProductId, UserId, model.type);
            }

            ShoppingCartViewModel viewModel = repository.GetShoppingCart(UserId, model.type);

            return PartialView("AddProductToShoppingCart", viewModel);
        }


        [HttpGet]
        public async Task<ActionResult> GetChartData()
        {
            string UserId = GetUser();


            CartStatisticsViewModel model = repository.GetStatistics(UserId);


            List<string> WeekLabel = model.Week.Expenses.Keys.ToList<string>();
            List<double> WeekData1 = model.Week.Expenses.Values.ToList();
            List<string> WeekData = new List<string>();
            foreach (var item in WeekData1)
            {
                WeekData.Add(item.ToString());
            }

            List<string> MonthLabel = model.Month.Expenses.Keys.ToList<string>();
            List<double> MonthData1 = model.Month.Expenses.Values.ToList();
            List<string> MonthData = new List<string>();
            foreach (var item in MonthData1)
            {
                MonthData.Add(item.ToString());
            }
            List<string> YearLabel = model.Year.Expenses.Keys.ToList<string>();
            List<double> YearData1 = model.Year.Expenses.Values.ToList();
            List<string> YearData = new List<string>();
            foreach (var item in YearData1)
            {
                YearData.Add(item.ToString());
            }


            return new JsonResult(new { WeekLabel = WeekLabel, WeekData = WeekData, MonthLabel = MonthLabel, MonthData = MonthData, YearLabel = YearLabel, YearData = YearData });
        }


        public PartialViewResult GetStatistics()
        {
            return PartialView("GetChartData");
        }



    }
}
