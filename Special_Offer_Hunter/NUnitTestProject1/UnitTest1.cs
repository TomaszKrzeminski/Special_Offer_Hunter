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
        [Test]
        public void When_AutoCompleteProductNameShort_Gets_ProductName_LowerCase_ProductX_Returns_ExampleProduct_3_to_7()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<HomeController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();

            List<string> listofProductNames = new List<string>() { "ExampleProduct3", "ExampleProduct4", "ExampleProduct5", "ExampleProduct6", "ExampleProduct7" };

            repo.Setup(r => r.AutoCompleteProductName("ProductX")).Returns(listofProductNames);






            HomeController controller = new HomeController(logger.Object, mockEnvironment.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);

            JsonResult result = controller.AutoCompleteProductNameShort("ProductX") as JsonResult;

            Assert.That(result, Is.InstanceOf<JsonResult>());


            List<string> list = result.Value as List<string>;

            Assert.AreEqual("ExampleProduct3", list[0]);
        }


        string GetUserNull()
        {
            return null;
        }


        [Test]
        public void GetPicture_When_Gets_Correct_Id_returns_PictureFile()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<HomeController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();

            List<string> listofProductNames = new List<string>() { "ExampleProduct3", "ExampleProduct4", "ExampleProduct5", "ExampleProduct6", "ExampleProduct7" };

            repo.Setup(r => r.AutoCompleteProductName("ProductX")).Returns(listofProductNames);






            HomeController controller = new HomeController(logger.Object, mockEnvironment.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);

            JsonResult result = controller.AutoCompleteProductNameShort("ProductX") as JsonResult;

            Assert.That(result, Is.InstanceOf<JsonResult>());


            List<string> list = result.Value as List<string>;

            Assert.AreEqual("ExampleProduct3", list[0]);
        }
        [Test]
        public void GetPicture_When_Gets_InCorrect_Id_returns_unnamed_jpg()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");

            mockEnvironment.Setup(x => x.ContentRootPath).Returns(@"C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\");

            var logger = new Mock<ILogger<HomeController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();

            repo.Setup(x => x.CheckPictureOwner("/Home/GetPicture/" + "FakeId", "TestId1")).Returns(false);





            HomeController controller = new HomeController(logger.Object, mockEnvironment.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);

            FileStreamResult result = ((FileStreamResult)controller.GetPicture("FakeId"));

            string FileName = result.FileDownloadName;




            Assert.AreEqual(result.FileDownloadName, @"C:\Users\tomek\Desktop\Repository_Special_Offer\Special_Offer_Hunter\Special_Offer_Hunter\UserImages\unnamed.jpg");
        }



    }



    public class CartControllerTests
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
        public void When_MoveProductToAnotherCart_Gets_Model_Changes_ShoppingCartType_And_Moves_Product()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<CartController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();



            List<string> listofShopNames = new List<string>() { "ExampleShop1", "ExampleShop2", "ExampleShop3" };

            repo.Setup(r => r.AddProductToUserShoppingCart("TestId1", ShoppingCartType.Dzień, 666)).Returns(true);
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel();
            repo.Setup(r => r.GetShoppingCart("TestId1", ShoppingCartType.Rok)).Returns(viewModel);



            CartController controller = new CartController(logger.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);

            MoveProductToCart model = new MoveProductToCart();

            ShoppingCartViewModel result = controller.MoveProductToAnotherCart(model).ViewData.Model as ShoppingCartViewModel;

            Assert.That(result, Is.InstanceOf<JsonResult>());




            Assert.AreEqual("ExampleShop1", list[0]);
        }




    }



}