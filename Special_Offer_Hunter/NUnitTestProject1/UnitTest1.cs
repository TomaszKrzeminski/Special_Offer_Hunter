using Castle.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Special_Offer_Hunter.Controllers;
using Special_Offer_Hunter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Tests
{
    public class HomeControllerTests
    {


        public class IdentityMocking
        {
            public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
            {
                var store = new Mock<IUserStore<TUser>>();
                var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
                mgr.Object.UserValidators.Add(new UserValidator<TUser>());
                mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

                mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
                mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
                mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

                return mgr;
            }

        }

        string GetUserX()
        {
            return "TestId1";
        }

        private List<ApplicationUser> _users = new List<ApplicationUser>()
         {
      new ApplicationUser(){UserName="User1",Id="Id1" } ,
      new ApplicationUser(){UserName="User2",Id="Id2" }
         };





        [Test]
        public void When_AutoCompleteShopShort_Gets_ShopName_LowerCase_Example_Returns_ExampleShops_1_to_3()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<HomeController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();

            List<string> listofShopNames = new List<string>() { "ExampleShop1", "ExampleShop2", "ExampleShop3" };

            repo.Setup(r => r.GetShopNamesAutocompleteShort("SHOPNAME")).Returns(listofShopNames);






            HomeController controller = new HomeController(logger.Object, mockEnvironment.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);

            JsonResult result = controller.AutoCompleteShopShort("shopname") as JsonResult;

            Assert.That(result, Is.InstanceOf<JsonResult>());


            List<string> list = result.Value as List<string>;

            Assert.AreEqual("ExampleShop1", list[0]);
        }








    }
}