using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
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
            viewModel.type = ShoppingCartType.Dzień;
            repo.Setup(r => r.GetShoppingCart("TestId1", ShoppingCartType.Dzień)).Returns(viewModel);



            CartController controller = new CartController(logger.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);

            MoveProductToCart model = new MoveProductToCart();
            model.MoveType = ShoppingCartType.Dzień;
            model.ProductId = 666;

            ShoppingCartViewModel result = controller.MoveProductToAnotherCart(model).ViewData.Model as ShoppingCartViewModel;

            Assert.AreEqual(result.type, ShoppingCartType.Dzień);

        }

        [Test]
        public void When_ProductId_In_Model_Is_Larger_Than_0_In_AddProductToShoppingCart_Than_AddProductToUserShoppingCart_Fires()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<CartController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();

            repo.Setup(x => x.AddProductToUserShoppingCart(It.IsAny<string>(), It.IsAny<ShoppingCartType>(), It.IsAny<int>())).Returns(true);




            CartController controller = new CartController(logger.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);

            AddProcutToShoppingCart model = new AddProcutToShoppingCart();
            model.ProductId = 1;

            ShoppingCartViewModel result = controller.AddProductToShoppingCart(model).ViewData.Model as ShoppingCartViewModel;

            Mock.Get(repo.Object).Verify(x => x.AddProductToUserShoppingCart(It.IsAny<string>(), It.IsAny<ShoppingCartType>(), It.IsAny<int>()), Times.Once);

        }



        [Test]
        public void When_ProductId_In_Model_Is_Smaller_Or_Equal_0_In_AddProductToShoppingCart_Than_AddProductToUserShoppingCart_Doesnt_Fire()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<CartController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();

            repo.Setup(x => x.AddProductToUserShoppingCart(It.IsAny<string>(), It.IsAny<ShoppingCartType>(), It.IsAny<int>())).Returns(true);




            CartController controller = new CartController(logger.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);

            AddProcutToShoppingCart model = new AddProcutToShoppingCart();
            model.ProductId = 0;

            ShoppingCartViewModel result = controller.AddProductToShoppingCart(model).ViewData.Model as ShoppingCartViewModel;

            Mock.Get(repo.Object).Verify(x => x.AddProductToUserShoppingCart(It.IsAny<string>(), It.IsAny<ShoppingCartType>(), It.IsAny<int>()), Times.Never);

        }

    }

    public class LoginControllerTests
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
        public async Task When_RemovePicture_Gets_Valid_Path_Returns_Model_With_Message_Empty()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<CartController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();


            repo.Setup(r => r.ChangeUserPicture(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            LoginController controller = new LoginController(mockEnvironment.Object, repo.Object, httpContextAccessor.Object, GetUserX);



            var result = await controller.RemovePicture("ExamplePath");
            PartialViewResult result2 = (PartialViewResult)(await controller.RemovePicture("ExamplePath"));
            UserImageFileNameViewModel x = result2.Model as UserImageFileNameViewModel;

            Assert.AreEqual(x.Message, "");

        }


        [Test]
        public async Task When_RemovePicture_Gets_InValid_Path_Returns_Model_With_Message_Problemyzusunięciempliku()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<CartController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();


            repo.Setup(r => r.ChangeUserPicture(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            LoginController controller = new LoginController(mockEnvironment.Object, repo.Object, httpContextAccessor.Object, GetUserX);



            var result = await controller.RemovePicture("ExamplePath");
            PartialViewResult result2 = (PartialViewResult)(await controller.RemovePicture("ExamplePath"));
            UserImageFileNameViewModel x = result2.Model as UserImageFileNameViewModel;

            Assert.AreEqual(x.Message, "Problemy z usunięciem pliku");

        }







    }

    public class ManagementProductsAndShopsControllerTests
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
        public async Task When_ShopName_Is_Null_In_AddShop_MOdelState_Is_Uzupelnijnazwesklepu()
        {

            var userManager = IdentityMocking.MockUserManager<ApplicationUser>(_users);

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");


            var logger = new Mock<ILogger<ManagementProductsAndShopsController>>();


            Mock<IHttpContextAccessor> httpContextAccessor = new Mock<IHttpContextAccessor>();

            Mock<IRepository> repo = new Mock<IRepository>();


            repo.Setup(r => r.ChangeUserPicture(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            ManagementProductsAndShopsController controller = new ManagementProductsAndShopsController(logger.Object, mockEnvironment.Object, repo.Object, userManager.Object, httpContextAccessor.Object, GetUserX);



            AddShopViewModel model = new AddShopViewModel();
            model.shop.Name = null;

            ViewResult result = controller.AddShop(model) as ViewResult;

            Assert.IsTrue(result.ViewData.ModelState["shop.Name"].Errors.Count > 0);

            Assert.AreEqual(result.ViewData.ModelState["shop.Name"].Errors[0].ErrorMessage, "Uzupełnij nazwę sklepu");



        }










    }





}