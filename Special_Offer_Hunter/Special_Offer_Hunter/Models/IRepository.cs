using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using Special_Offer_Hunter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Special_Offer_Hunter.Models;
using System.Globalization;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.RegularExpressions;


namespace Special_Offer_Hunter.Models
{
    public interface IRepository
    {

        string CheckIfNewProductExists(string Barcode, string Shop, double Price);


        bool AddShop(AddShopViewModel model);
        bool AddProduct(AddNewProductViewModel model);
        List<string> GetShopNamesAutocomplete(string Name);
        List<string> GetCompanyNamesAutocomplete(string Name);
        List<string> GetShopNames(string Name);
        List<string> GetOwnerNames(string Name);
        Dictionary<string, string> GetOwnerNames2(string Name);
        Product GetProductById(int Id);
        Product GetProductByName(string Name);
        Product GetProductByCode(string Code);
        Location GetUserLocation(string UserId);
        List<string> GetCategories();

        public string GetUserEmail(string UserId);
        bool ChangeNumberOfProducts(double number, int ProductId, string UserId, ShoppingCartType type);
        bool RemoveProductBought(int ProductId, string UserId);
        bool AddProductToUserShoppingCart(string UserId, ShoppingCartType type, int ProductId);
        bool RemoveProductFromShoppingCart(string UserId, ShoppingCartType type, int ProductId);
        public ShoppingCartViewModel GetShoppingCart(string UserId, ShoppingCartType type);
        List<Product> GetProductsWithSpecialOffer2(SpecialOfferViewModel offer);
        bool AddPriceToProduct(int ProductId, double Price);

        List<ProductLocation> GetProductLocationByCartType(ShoppingCartType type, string UserId);

        bool AddProduct(Product product);

        bool SaveCoordinatesAppUser(double Latitude, double Longitude, string UserId);

        public Dictionary<Product, double> GetProductsWithSpecialOffer(SpecialOfferViewModel offer);

        CartStatisticsViewModel GetStatistics(string UserId);

        Shop_Comment AddCommentToShop(string UserId, Shop_Comment comment);
        Shop_Rank AddRankToShop(string UserId, Shop_Rank rank);

        ShopRanksAndCommentsViewModel GetRankAndCommentShopViewModel(int ShopId, string UserId);
        Product_Rank AddRankToProduct(string userId, Product_Rank data);
        public Product_Comment AddCommentToProduct(string UserId, Product_Comment comment);
        ProductRanksAndCommentsViewModel GetRankAndCommentProductViewModel(int ProductId, string UserId);

        ApplicationUser GetUserData(string UserId);

        bool ChangeUser(ApplicationUser user);

        bool ChangeUserPicture(string UserId, string Path);

        bool CheckPictureOwner(string Path, string UserId);
    }


    public static class ExtensionForOffers
    {
        public static IQueryable<Product> WhereOnSale(this IQueryable<Shop> source)
        {
            return source.Where(x => x.Name == "xx").FirstOrDefault().Products.AsQueryable();
        }
    }

    public class Repository : IRepository
    {
        ApplicationDbContext context;
        IHostingEnvironment env;
        public Repository(ApplicationDbContext ctx, IHostingEnvironment _environment)
        {
            env = _environment;
            context = ctx;
        }

        //public bool AddPriceToProduct(int ProductId, double Price)
        //{
        //    try
        //    {
        //        Product product = context.Products.Find(ProductId);
        //        Product_Price price = new Product_Price(Price);
        //        price.Products.Add(product);
        //        context.Product_Prices.Add(price);
        //        context.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}


        public bool AddPriceToProduct(int ProductId, double Price)
        {
            try
            {
                Product product = context.Products.Find(ProductId);
                product.Last_ProductPrice = product.Product_Price;
                product.Product_Price = Price;

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool AddProduct(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product GetProductByCode(string Code)
        {
            Product product = new Product();
            try
            {
                product = context.Products.Include(x => x.Product_Code).Where(x => x.Product_Code.Code == Code).FirstOrDefault();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CheckDay(DateTime compare)
        {
            bool check = false;
            DateTime date = DateTime.Now;
            if (compare.Year == date.Year && compare.Month == date.Month && compare.DayOfWeek == date.DayOfWeek)
            {
                check = DateTime.Today.Day == compare.Day;
            }



            return check;

        }
        public bool CheckMonth(DateTime a)
        {
            DateTime b = DateTime.Now;

            if (a.Year == b.Year && a.Month == b.Month)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckWeek(DateTime a)
        {
            DateTime Now = DateTime.Now;
            CultureInfo poland = new CultureInfo("pl-PL");
            Calendar myCal = poland.Calendar;
            CalendarWeekRule myCWR = poland.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = poland.DateTimeFormat.FirstDayOfWeek;


            int X = myCal.GetWeekOfYear(Now, myCWR, myFirstDOW);
            int Y = myCal.GetWeekOfYear(a, myCWR, myFirstDOW);


            if (X == Y)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool CheckYear(DateTime a)
        {

            DateTime b = DateTime.Now;

            if (a.Year == b.Year)
            {
                return true;
            }
            else
            {
                return false;
            }




        }
        public ShoppingCartViewModel GetShoppingCart(string UserId, ShoppingCartType type)
        {

            ShoppingCartViewModel model = new ShoppingCartViewModel();
            model.type = type;
            model.UserId = UserId;
            List<Product> list = new List<Product>();
            List<ShoppingDetails> listDetails = new List<ShoppingDetails>();
            try
            {
                ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Days)/*.Include(x => x.Shopping_Cart_Weeks).Include(x => x.Shopping_Cart_Months).Include(x => x.Shopping_Cart_Years)*/.Include(x => x.Shopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();
                DateTime now = DateTime.Now;
                switch (type)
                {
                    case ShoppingCartType.Dzień:

                        Shopping_Cart_Day cart = context.Shopping_Carts_Day.Include(x => x.ProductShopping_Cart_Days).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_DayId == user.Shopping_Cart_Days.Last().Shopping_Cart_DayId).FirstOrDefault();
                        list = cart.ProductShopping_Cart_Days.Select(x => x.Product).ToList();
                        DateTime date = DateTime.Now;


                        foreach (var item in list)
                        {

                            List<ProductsBought> listBought = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.ProductId == item.ProductId).ToList();

                            double number = 0;

                            foreach (var item2 in listBought)
                            {
                                bool check = CheckDay(item2.Time);

                                if (check)
                                {
                                    number = item2.Number;
                                }


                            }

                            listDetails.Add(new ShoppingDetails() { product = item, ProductNumber = number });


                        }
                        break;
                    case ShoppingCartType.Tydzień:
                        List<ProductsBought> listBought2 = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.Time.Year == now.Year && x.Time.Month == x.Time.Month).ToList();

                        for (int i = 0; i < listBought2.Count(); i++)
                        {


                            if (CheckWeek(listBought2[i].Time))
                            {
                                Product product = context.Products.Find(listBought2[i].ProductId);

                                if (!listDetails.Any(x => x.product.ProductId == product.ProductId))
                                {

                                    listDetails.Add(new ShoppingDetails() { product = product, ProductNumber = listBought2[i].Number });
                                }
                                else
                                {
                                    ShoppingDetails det = listDetails.Where(x => x.product.ProductId == product.ProductId).FirstOrDefault();
                                    det.ProductNumber += listBought2[i].Number;
                                }




                            }



                        }


                        break;
                    case ShoppingCartType.Miesiąc:
                        List<ProductsBought> listBought3 = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.Time.Year == now.Year && x.Time.Month == x.Time.Month).ToList();

                        for (int i = 0; i < listBought3.Count(); i++)
                        {


                            if (CheckMonth(listBought3[i].Time))
                            {
                                Product product = context.Products.Find(listBought3[i].ProductId);

                                if (!listDetails.Any(x => x.product.ProductId == product.ProductId))
                                {

                                    listDetails.Add(new ShoppingDetails() { product = product, ProductNumber = listBought3[i].Number });
                                }
                                else
                                {
                                    ShoppingDetails det = listDetails.Where(x => x.product.ProductId == product.ProductId).FirstOrDefault();
                                    det.ProductNumber += listBought3[i].Number;
                                }




                            }



                        }


                        break;
                    case ShoppingCartType.Rok:
                        List<ProductsBought> listBought4 = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.Time.Year == now.Year).ToList();

                        for (int i = 0; i < listBought4.Count(); i++)
                        {


                            if (CheckYear(listBought4[i].Time))
                            {
                                Product product = context.Products.Find(listBought4[i].ProductId);

                                if (!listDetails.Any(x => x.product.ProductId == product.ProductId))
                                {

                                    listDetails.Add(new ShoppingDetails() { product = product, ProductNumber = listBought4[i].Number });
                                }
                                else
                                {
                                    ShoppingDetails det = listDetails.Where(x => x.product.ProductId == product.ProductId).FirstOrDefault();
                                    det.ProductNumber += listBought4[i].Number;
                                }




                            }



                        }

                        break;
                    case ShoppingCartType.Poszukiwane:
                        Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.ProductShopping_Cart_LookFor).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Last().Shopping_Cart_LookForId).FirstOrDefault();
                        list = cart4.ProductShopping_Cart_LookFor.Select(x => x.Product).ToList();
                        foreach (var item in list)
                        {



                            listDetails.Add(new ShoppingDetails() { product = item, ProductNumber = 0 });


                        }
                        break;

                }

                model.productList = listDetails;

                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }
        public Product GetProductById(int Id)
        {
            Product product = new Product();
            try
            {
                product = context.Products.Find(Id);
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product GetProductByName(string Name)
        {
            Product product = new Product();
            try
            {
                product = context.Products.Where(x => x.Name == Name).FirstOrDefault();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public List<Product> GetProductsWithPrice(double Price)
        //{
        //    try
        //    {
        //        Product_Price x = context.Product_Prices.Include(x => x.Products).Where(x => x.Price == Price).FirstOrDefault();
        //        List<Product> list = context.Product_Prices.Include(x => x.Products).Where(x => x.Price == Price).AsQueryable().ToList().SelectMany(x => x.Products).ToList();
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public List<Product> GetProductsWithPrice(double Price)
        {
            try
            {

                List<Product> list = context.Products.Where(x => x.Product_Price == Price).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static Point CreatePoint(double latitude, double longitude)
        {
            // 4326 is most common coordinate system used by GPS/Maps
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            // see https://docs.microsoft.com/en-us/ef/core/modeling/spatial
            // Longitude and Latitude
            var newLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));

            return newLocation;
        }
        public List<Product> GetProductsWithSpecialOffer2(SpecialOfferViewModel offer)
        {
            try
            {
                double latitude = offer.MyLocation.Latitude;
                double longitude = offer.MyLocation.Longitude;



                Point mylocation = new NetTopologySuite.Geometries.Point(18.451, 53.411) { SRID = 4326 };

                List<double> listProd2 = context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Include(x => x.Location)
                   .Select(x => (x.Location.location.Distance(mylocation) / 1000)).ToList();




                List<Product> listProd = context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Include(x => x.Location)
                    .Where(x => (x.Location.location.Distance(mylocation) / 1000) < offer.Distance)
                    .Where(offer.SearchShop).SelectMany(x =>
                   x.Products).AsQueryable()
                    .Where(offer.SearchProductByCategory)
                    .Where(offer.SearchProductByProductName)
                    .Where(offer.SearchProductByPrice).Take<Product>(15).ToList();


                Dictionary<Product, double> dictionary = new Dictionary<Product, double>();
                Point mylocation2 = new NetTopologySuite.Geometries.Point(18.451, 53.411) { SRID = 4326 };

                List<double> list = listProd.Select(x => (x.Shop.Location.location.Distance(mylocation2) / 1000)).ToList();

                foreach (var item in listProd)
                {



                    double Distance = (item.Shop.Location.location.Distance(mylocation) / 1000);
                    dictionary.Add(item, Distance);

                }


                return listProd;

            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public static Expression<Func<Product, string>> OrderDescending = d => d.Name;
        //public static Expression<Func<Product, double>> OrderDescending2Price = d => d.Product_Price.Price;
        public static Expression<Func<Product, double>> OrderDescending2Price = d => d.Product_Price;

        /// <summary>
        /// Odblokuj lokalizacje przed udostępnieniem
        /// </summary>       
        /// <returns></returns>
        public Dictionary<Product, double> GetProductsWithSpecialOffer(SpecialOfferViewModel offer)
        {

            //Dodaj special offer lub nie
            try
            {

                double latitude = offer.MyLocation.Latitude;
                double longitude = offer.MyLocation.Longitude;
                Point mylocation = CreatePoint(53.411, 18.451);


                List<Product> listProd2 = context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Include(x => x.Location)
                   .Where(x => (x.Location.location.Distance(mylocation) / 1000) < offer.Distance)
                   .Where(offer.SearchShop).SelectMany(x => x.Products).AsQueryable().Where(offer.SearchProductByBarCode).ToList();


                List<Product> listProd = context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Include(x => x.Location)
                   .Where(x => (x.Location.location.Distance(mylocation) / 1000) < offer.Distance)
                   .Where(offer.SearchShop).SelectMany(x => x.Products).AsQueryable().Where(offer.SearchProductByBarCode)
                   .Where(offer.SearchProductBySpecialOffer)
                   .Where(offer.SearchProductByCategory)
                   .Where(offer.SearchProductByProductName)
                   .Where(offer.SearchProductByPrice).Take<Product>(15).ToList();

                Dictionary<Product, double> dictionary = new Dictionary<Product, double>();

                foreach (var item in listProd)
                {
                    Dictionary<Shop, double> shop = context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Include(x => x.Location).Where(x => x.ShopId == item.Shop.ShopId)
                   .Select(x => new KeyValuePair<Shop, double>(x, x.Location.location.Distance(mylocation) / 1000)).ToDictionary(x => x.Key, x => x.Value);

                    var x = shop.First();
                    dictionary.Add(item, x.Value);
                }

                if (offer.sortType == SortType.Malejąco)
                {

                    dictionary = dictionary.OrderByDescending(offer.SortProduct).ToDictionary(x => x.Key, x => x.Value);

                }
                else
                {
                    dictionary = dictionary.OrderBy(offer.SortProduct).ToDictionary(x => x.Key, x => x.Value);

                }

                return dictionary;

            }
            catch (Exception ex)
            {
                return new Dictionary<Product, double>();
            }
        }

        public Location GetUserLocation(string UserId)
        {
            try
            {
                Location location = new Location();


                //ApplicationUser user = context.Users.Find(UserId);
                //location.Latitude = user.Latitude;
                //location.Longitude = user.Longitude;


                //// wersja testowa
                location.Latitude = 53.411008;
                location.Longitude = 18.451573;
                ///


                return location;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveCoordinatesAppUser(double Latitude, double Longitude, string UserId)
        {
            try
            {

                ApplicationUser user = context.Users.Find(UserId);
                user.Longitude = Longitude;
                user.Latitude = Latitude;
                user.userlocation = new NetTopologySuite.Geometries.Point(Longitude, Latitude) { SRID = 4326 };
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool AddProductToUserShoppingCart(string UserId, ShoppingCartType type, int ProductId)
        {
            try
            {
                Product product = context.Products.Find(ProductId);
                int CartId = 0;

                ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Days).ThenInclude(x => x.ProductShopping_Cart_Days).Include(x => x.Shopping_Cart_LookFor).ThenInclude(x => x.ProductShopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();

                switch (type)
                {
                    case ShoppingCartType.Dzień:


                        if (user.Shopping_Cart_Days.Count() == 0)
                        {
                            Shopping_Cart_Day cartDay = new Shopping_Cart_Day();
                            cartDay.DateFrom = DateTime.Now;
                            cartDay.DateTo = DateTime.Now.AddDays(1);
                            context.Shopping_Carts_Day.Add(cartDay);
                            context.SaveChanges();
                            CartId = cartDay.Shopping_Cart_DayId;
                            ApplicationUser userX = context.Users.Find(UserId);
                            Shopping_Cart_Day day = context.Shopping_Carts_Day.Find(CartId);
                            userX.Shopping_Cart_Days.Add(day);
                            context.SaveChanges();
                        }

                        Shopping_Cart_Day cart = context.Shopping_Carts_Day.Include(x => x.ProductShopping_Cart_Days).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_DayId == user.Shopping_Cart_Days.Last().Shopping_Cart_DayId).FirstOrDefault();

                        if (!cart.ProductShopping_Cart_Days.Any(x => x.ProductId == ProductId))
                        {

                            ProductShopping_Cart_Day pcd = new ProductShopping_Cart_Day();
                            Product prod = context.Products.Find(ProductId);

                            pcd.Product = prod;
                            pcd.Shopping_Cart_Day = cart;

                            context.ProductShopping_Carts_Days.Add(pcd);
                            context.SaveChanges();
                        }


                        break;
                    //case ShoppingCartType.Tydzień:

                    //    if (user.Shopping_Cart_Weeks.Count() == 0)
                    //    {
                    //        Shopping_Cart_Week cartWeek = new Shopping_Cart_Week();
                    //        context.Shopping_Carts_Week.Add(cartWeek);
                    //        context.SaveChanges();
                    //        CartId = cartWeek.Shopping_Cart_WeekId;
                    //        ApplicationUser userX = context.Users.Find(UserId);
                    //        Shopping_Cart_Week week = context.Shopping_Carts_Week.Find(CartId);
                    //        userX.Shopping_Cart_Weeks.Add(week);
                    //        context.SaveChanges();
                    //    }
                    //    Shopping_Cart_Week cart1 = context.Shopping_Carts_Week.Include(x => x.ProductShopping_Cart_Weeks).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_WeekId == user.Shopping_Cart_Weeks.Last().Shopping_Cart_WeekId).FirstOrDefault();
                    //    if (!cart1.ProductShopping_Cart_Weeks.Any(x => x.ProductId == ProductId))
                    //    {
                    //        ProductShopping_Cart_Week pcd = new ProductShopping_Cart_Week();
                    //        Product prod = context.Products.Find(ProductId);

                    //        pcd.Product = prod;
                    //        pcd.Shopping_Cart_Week = cart1;

                    //        context.ProductShopping_Carts_Weeks.Add(pcd);
                    //        context.SaveChanges();
                    //    }
                    //    break;
                    //case ShoppingCartType.Miesiąc:
                    //    if (user.Shopping_Cart_Months.Count() == 0)
                    //    {
                    //        Shopping_Cart_Month cartM = new Shopping_Cart_Month();
                    //        context.Shopping_Cart_Month.Add(cartM);
                    //        context.SaveChanges();
                    //        CartId = cartM.Shopping_Cart_MonthId;
                    //        ApplicationUser userX = context.Users.Find(UserId);
                    //        Shopping_Cart_Month day = context.Shopping_Cart_Month.Find(CartId);
                    //        userX.Shopping_Cart_Months.Add(day);
                    //        context.SaveChanges();
                    //    }
                    //    Shopping_Cart_Month cart2 = context.Shopping_Cart_Month.Include(x => x.ProductShopping_Cart_Months).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_MonthId == user.Shopping_Cart_Months.Last().Shopping_Cart_MonthId).FirstOrDefault();
                    //    if (!cart2.ProductShopping_Cart_Months.Any(x => x.ProductId == ProductId))
                    //    {
                    //        ProductShopping_Cart_Month pcd = new ProductShopping_Cart_Month();
                    //        Product prod = context.Products.Find(ProductId);

                    //        pcd.Product = prod;
                    //        pcd.Shopping_Cart_Month = cart2;

                    //        context.ProductShopping_Cart_Months.Add(pcd);
                    //        context.SaveChanges();
                    //    }
                    //    break;
                    //case ShoppingCartType.Rok:
                    //    if (user.Shopping_Cart_Years.Count() == 0)
                    //    {
                    //        Shopping_Cart_Year cartY = new Shopping_Cart_Year();
                    //        context.Shopping_Cart_Year.Add(cartY);
                    //        context.SaveChanges();
                    //        CartId = cartY.Shopping_Cart_YearId;
                    //        ApplicationUser userX = context.Users.Find(UserId);
                    //        Shopping_Cart_Year day = context.Shopping_Cart_Year.Find(CartId);
                    //        userX.Shopping_Cart_Years.Add(day);
                    //        context.SaveChanges();
                    //    }
                    //    Shopping_Cart_Year cart3 = context.Shopping_Cart_Year.Include(x => x.ProductShopping_Cart_Years).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_YearId == user.Shopping_Cart_Years.Last().Shopping_Cart_YearId).FirstOrDefault();
                    //    if (!cart3.ProductShopping_Cart_Years.Any(x => x.ProductId == ProductId))
                    //    {
                    //        ProductShopping_Cart_Year pcd = new ProductShopping_Cart_Year();
                    //        Product prod = context.Products.Find(ProductId);

                    //        pcd.Product = prod;
                    //        pcd.Shopping_Cart_Year = cart3;

                    //        context.ProductShopping_Cart_Years.Add(pcd);
                    //        context.SaveChanges();
                    //    }
                    //    break;
                    case ShoppingCartType.Poszukiwane:
                        if (user.Shopping_Cart_LookFor.Count() == 0)
                        {
                            Shopping_Cart_LookFor cartL = new Shopping_Cart_LookFor();
                            context.Shopping_Cart_LookFor.Add(cartL);
                            context.SaveChanges();
                            CartId = cartL.Shopping_Cart_LookForId;
                            ApplicationUser userX = context.Users.Find(UserId);
                            Shopping_Cart_LookFor day = context.Shopping_Cart_LookFor.Find(CartId);
                            userX.Shopping_Cart_LookFor.Add(day);
                            context.SaveChanges();
                        }
                        Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.ProductShopping_Cart_LookFor).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Last().Shopping_Cart_LookForId).FirstOrDefault();
                        if (!cart4.ProductShopping_Cart_LookFor.Any(x => x.ProductId == ProductId))
                        {
                            ProductShopping_Cart_LookFor pcd = new ProductShopping_Cart_LookFor();
                            Product prod = context.Products.Find(ProductId);

                            pcd.Product = prod;
                            pcd.Shopping_Cart_LookFor = cart4;

                            context.ProductShopping_Cart_LookFor.Add(pcd);
                            context.SaveChanges();
                        }
                        break;

                }






                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveProductFromShoppingCart(string UserId, ShoppingCartType type, int ProductId)
        {
            try
            {
                ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Days)/*.Include(x => x.Shopping_Cart_Weeks).Include(x => x.Shopping_Cart_Months).Include(x => x.Shopping_Cart_Years)*/.Include(x => x.Shopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();
                Product product = context.Products.Find(ProductId);
                switch (type)
                {
                    case ShoppingCartType.Dzień:
                        Shopping_Cart_Day cart = context.Shopping_Carts_Day.Include(x => x.ProductShopping_Cart_Days).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_DayId == user.Shopping_Cart_Days.Last().Shopping_Cart_DayId).First();

                        ProductShopping_Cart_Day r = cart.ProductShopping_Cart_Days.Where(x => x.ProductId == ProductId).FirstOrDefault();
                        cart.ProductShopping_Cart_Days.Remove(r);
                        context.SaveChanges();
                        DateTime date = DateTime.Now;



                        ProductsBought Remove = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).SelectMany(x => x.ProductsBought).Where(x => x.ProductId == ProductId && x.Time.Year == date.Year && x.Time.Month == date.Month && x.Time.Day == date.Day).FirstOrDefault();
                        user.ProductsBought.Remove(Remove);
                        context.SaveChanges();



                        break;

                    case ShoppingCartType.Poszukiwane:
                        Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.ProductShopping_Cart_LookFor).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Last().Shopping_Cart_LookForId).First();

                        ProductShopping_Cart_LookFor r4 = cart4.ProductShopping_Cart_LookFor.Where(x => x.ProductId == ProductId).FirstOrDefault();
                        cart4.ProductShopping_Cart_LookFor.Remove(r4);
                        context.SaveChanges();

                        ProductsBought Remove2 = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).SelectMany(x => x.ProductsBought).Where(x => x.ProductId == ProductId && x.cartType == ShoppingCartType.Poszukiwane).FirstOrDefault();
                        user.ProductsBought.Remove(Remove2);
                        context.SaveChanges();



                        break;

                }




                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<string> GetCategories()
        {
            List<string> list = new List<string>();
            try
            {
                list = context.Categories.Select(x => x.Name).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public List<ProductLocation> GetProductLocationByCartType(ShoppingCartType type, string UserId)
        {
            ApplicationUser user = context.Users.Find(UserId);
            List<ProductLocation> list = new List<ProductLocation>();
            List<Product> productList = new List<Product>();
            try
            {

                switch (type)
                {
                    case ShoppingCartType.Dzień:
                        Shopping_Cart_Day cart = context.Shopping_Carts_Day.Include(x => x.ProductShopping_Cart_Days).ThenInclude(x => x.Product).ThenInclude(x => x.Shop).ThenInclude(x => x.Location).Where(x => x.Shopping_Cart_DayId == user.Shopping_Cart_Days.Last().Shopping_Cart_DayId).FirstOrDefault();
                        productList = cart.ProductShopping_Cart_Days.Select(x => x.Product).ToList();
                        break;

                    case ShoppingCartType.Poszukiwane:
                        Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.ProductShopping_Cart_LookFor).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Last().Shopping_Cart_LookForId).FirstOrDefault();
                        productList = cart4.ProductShopping_Cart_LookFor.Select(x => x.Product).ToList();
                        break;

                }

                List<Product> listBought = new List<Product>();

                if (productList != null && productList.Count > 0 && type == ShoppingCartType.Dzień)
                {

                    foreach (var p in productList)
                    {
                        bool check = false;

                        if (type == ShoppingCartType.Dzień)
                        {

                            check = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Any(x => x.ProductId == p.ProductId && x.Number > 0 && x.cartType == ShoppingCartType.Dzień && x.Time.Year == DateTime.Now.Year && x.Time.Month == DateTime.Now.Month && x.Time.Day == DateTime.Now.Day);

                        }


                        if (check)
                        {
                            listBought.Add(p);
                        }
                        //check = false;

                    }
                    productList = listBought;

                }





                if (productList != null && productList.Count > 0)
                {

                    foreach (var p in productList)
                    {

                        ProductLocation location = new ProductLocation();
                        location.location = p.Shop.Location;
                        location.product = p;
                        location.shop = p.Shop;

                        list.Add(location);
                    }


                }






                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }



        public bool ChangeNumberOfProducts(double number, int ProductId, string UserId, ShoppingCartType type)
        {
            try
            {


                ProductsBought prodB = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.ProductId == ProductId && x.Time.Day == DateTime.Now.Day).FirstOrDefault();
                Product product = context.Products.Include(x => x.Product_Price).Where(x => x.ProductId == ProductId).FirstOrDefault();
                ApplicationUser user = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault();
                bool check = false;


                if (type == ShoppingCartType.Dzień)
                {
                    if (prodB == null)
                    {
                        ProductsBought prodB1 = new ProductsBought();
                        prodB1.ProductId = ProductId;
                        prodB1.Number = number;
                        //prodB1.Price = product.Product_Price.Price;
                        prodB1.Price = product.Product_Price;
                        prodB1.Time = DateTime.Now;
                        prodB1.cartType = type;

                        user.ProductsBought.Add(prodB1);
                        context.SaveChanges();
                        return true;

                    }
                    else
                    {
                        check = CheckDay(prodB.Time);
                        if (check)
                        {
                            prodB.Number = number;
                            //prodB.Price = product.Product_Price.Price;
                            prodB.Price = product.Product_Price;
                            prodB.Time = DateTime.Now;
                            prodB.cartType = type;
                            context.SaveChanges();
                            return true;
                        }
                    }





                }




                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CartStatisticsViewModel GetStatistics(string UserId)
        {
            CartStatisticsViewModel model = new CartStatisticsViewModel();
            DateTime Now = DateTime.Now;
            try
            {
                ///Week
                List<ProductsBought> listWeek = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.Time.Month == Now.Month).ToList();
                List<ProductsBought> listWeekCheckded = new List<ProductsBought>();

                CultureInfo poland = new CultureInfo("pl-PL");
                Calendar myCal = poland.Calendar;
                CalendarWeekRule myCWR = poland.DateTimeFormat.CalendarWeekRule;
                DayOfWeek myFirstDOW = poland.DateTimeFormat.FirstDayOfWeek;


                int X = myCal.GetWeekOfYear(Now, myCWR, myFirstDOW);


                foreach (var item in listWeek)
                {
                    int Y = myCal.GetWeekOfYear(item.Time, myCWR, myFirstDOW);
                    if (X == Y)
                    {
                        listWeekCheckded.Add(item);
                    }


                }


                for (int i = 0; i < model.Week.Expenses.Keys.Count(); i++)
                {

                    double all = 0;

                    for (int j = 0; j < listWeekCheckded.Count(); j++)
                    {
                        string Day = listWeekCheckded[j].Time.ToString("dddd", poland);

                        if (Day == model.Week.Expenses.ElementAt(i).Key)
                        {
                            all += (listWeekCheckded[j].Price * listWeekCheckded[j].Number);
                        }


                    }
                    string key = model.Week.Expenses.ElementAt(i).Key;
                    model.Week.Expenses[key] = all;
                    all = 0;


                }


                /// Month
                List<ProductsBought> listMonth = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.Time.Year == Now.Year).ToList();
                List<ProductsBought> listMonthCheckded = listMonth;


                for (int i = 0; i < model.Month.Expenses.Keys.Count(); i++)
                {

                    double all = 0;

                    for (int j = 0; j < listMonthCheckded.Count(); j++)
                    {
                        string Month = listMonthCheckded[j].Time.ToString("MMMM").ToUpper();

                        if (Month == (model.Month.Expenses.ElementAt(i).Key).ToUpper())
                        {
                            all += (listMonthCheckded[j].Price * listMonthCheckded[j].Number);
                        }


                    }
                    string key = model.Month.Expenses.ElementAt(i).Key;
                    model.Month.Expenses[key] = all;
                    all = 0;


                }


                ///
                /// Year

                int YearFrom = Int32.Parse(model.Year.Expenses.Keys.First());
                int YearTo = Int32.Parse(model.Year.Expenses.Keys.Last());

                List<ProductsBought> listYears = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.Time.Year >= YearFrom && x.Time.Year <= YearTo).ToList();
                List<ProductsBought> listYearsCheckded = listYears;

                for (int i = 0; i < model.Year.Expenses.Keys.Count(); i++)
                {

                    double all = 0;

                    for (int j = 0; j < listYearsCheckded.Count(); j++)
                    {
                        int Year = listYearsCheckded[j].Time.Year;

                        if (Year == Int32.Parse(model.Year.Expenses.ElementAt(i).Key))
                        {
                            all += (listYearsCheckded[j].Price * listYearsCheckded[j].Number);
                        }


                    }
                    string key = model.Year.Expenses.ElementAt(i).Key;
                    model.Year.Expenses[key] = all;
                    all = 0;


                }


                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }


        bool CheckIfRankedShop(int ShopId, string UserId)
        {
            bool check = context.Users.Include(x => x.UserShopRanks).Where(x => x.Id == UserId).SelectMany(x => x.UserShopRanks).Any(x => x.ShopId == ShopId);


            if (check == true)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        bool CheckIfCommentedShop(int ShopId, string UserId)
        {
            bool check = context.Users.Include(x => x.UserShopComments).Where(x => x.Id == UserId).SelectMany(x => x.UserShopComments).Any(x => x.ShopId == ShopId);
            if (check == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public Shop_Comment AddCommentToShop(string UserId, Shop_Comment comment)
        {
            try
            {

                bool check = CheckIfCommentedShop(comment.ShopId, UserId);

                if (check == false)
                {
                    return null;
                }

                Shop shop = context.Shops.Include(x => x.Comments).Where(x => x.ShopId == comment.ShopId).FirstOrDefault();
                ApplicationUser user = context.Users.Include(x => x.UserShopComments).Where(x => x.Id == UserId).FirstOrDefault();

                if (shop != null)
                {
                    comment.Time = DateTime.Now;
                    shop.Comments.Add(comment);
                    user.UserShopComments.Add(comment);
                }
                else
                {
                    return null;
                }
                context.SaveChanges();
                return comment;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Shop_Rank AddRankToShop(string UserId, Shop_Rank rank)
        {
            try
            {

                bool check = CheckIfRankedShop(rank.ShopId, UserId);

                if (check == false)
                {
                    return null;
                }


                Shop shop = context.Shops.Include(x => x.Ranks).Where(x => x.ShopId == rank.ShopId).FirstOrDefault();
                ApplicationUser user = context.Users.Include(x => x.UserShopRanks).Where(x => x.Id == UserId).FirstOrDefault();

                if (shop != null)
                {
                    shop.Ranks.Add(rank);
                    user.UserShopRanks.Add(rank);
                }
                else
                {
                    return null;
                }
                context.SaveChanges();
                return rank;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShopRanksAndCommentsViewModel GetRankAndCommentShopViewModel(int ShopId, string UserId)
        {
            ShopRanksAndCommentsViewModel model = new ShopRanksAndCommentsViewModel();
            try
            {
                model.Comment = CheckIfCommentedShop(ShopId, UserId);
                model.Rank = CheckIfRankedShop(ShopId, UserId);
                model.ShopId = ShopId;
                List<Shop_Comment> list = context.Users.Include(x => x.UserShopComments).Where(x => x.Id == UserId).FirstOrDefault().UserShopComments.Where(x => x.ShopId == ShopId).ToList();
                model.listOfComments = list;
                model.shopComments = list.Count();
                model.ShopName = context.Shops.Find(ShopId).Name;

                model.shopRank = (int)context.Users.Where(x => x.Id == UserId).FirstOrDefault().UserShopRanks.Where(x => x.ShopId == ShopId).Select(x => x.Rank).Average();
                model.UserImage = context.Users.Find(UserId).UserImagePath;
                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
        }
        bool CheckIfRankedProduct(int ProductId, string UserId)
        {
            bool check = context.Users.Include(x => x.UserProductRanks).Where(x => x.Id == UserId).SelectMany(x => x.UserProductRanks).Any(x => x.ProductId == ProductId);


            if (check == true)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        bool CheckIfCommentedProduct(int ProductId, string UserId)
        {
            bool check = context.Users.Include(x => x.UserProductComments).Where(x => x.Id == UserId).SelectMany(x => x.UserProductComments).Any(x => x.ProductId == ProductId);
            if (check == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public Product_Rank AddRankToProduct(string UserId, Product_Rank rank)
        {
            try
            {

                bool check = CheckIfRankedProduct(rank.ProductId, UserId);

                if (check == false)
                {
                    return null;
                }


                Product product = context.Products.Include(x => x.Ranks).Where(x => x.ProductId == rank.ProductId).FirstOrDefault();
                ApplicationUser user = context.Users.Include(x => x.UserShopRanks).Where(x => x.Id == UserId).FirstOrDefault();

                if (product != null)
                {
                    product.Ranks.Add(rank);
                    user.UserProductRanks.Add(rank);
                }
                else
                {
                    return null;
                }
                context.SaveChanges();
                return rank;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductRanksAndCommentsViewModel GetRankAndCommentProductViewModel(int ProductId, string UserId)
        {
            ProductRanksAndCommentsViewModel model = new ProductRanksAndCommentsViewModel();
            try
            {
                model.Comment = CheckIfCommentedProduct(ProductId, UserId);
                model.Rank = CheckIfRankedProduct(ProductId, UserId);
                model.ProductId = ProductId;
                List<Product_Comment> list = context.Users.Include(x => x.UserProductComments).Where(x => x.Id == UserId).FirstOrDefault().UserProductComments.Where(x => x.ProductId == ProductId).ToList();
                model.listOfComments = list;
                model.productComments = list.Count();
                string productName = context.Products.Find(ProductId).Name;
                int MaxLength = 20;

                if (productName.Length > MaxLength)
                {
                    model.ProductName = productName.Substring(0, MaxLength);
                }
                else
                {
                    model.ProductName = productName;
                }



                model.UserImage = context.Users.Find(UserId).UserImagePath;



                List<int> average = context.Users.Include(x => x.UserProductRanks).Where(x => x.Id == UserId).FirstOrDefault().UserProductRanks.Where(x => x.ProductId == ProductId).Select(x => x.Rank).ToList();

                if (average != null && average.Count() > 0)
                {
                    model.productRank = (int)average.Average();
                }





                return model;
            }
            catch (Exception ex)
            {
                return model;

            }
        }

        public Product_Comment AddCommentToProduct(string UserId, Product_Comment comment)
        {
            try
            {

                bool check = CheckIfCommentedProduct(comment.ProductId, UserId);

                if (check == false)
                {
                    return null;
                }

                Product product = context.Products.Include(x => x.Comments).Where(x => x.ProductId == comment.ProductId).FirstOrDefault();
                ApplicationUser user = context.Users.Include(x => x.UserShopComments).Where(x => x.Id == UserId).FirstOrDefault();

                if (product != null)
                {
                    comment.Time = DateTime.Now;
                    product.Comments.Add(comment);
                    user.UserProductComments.Add(comment);
                }
                else
                {
                    return null;
                }
                context.SaveChanges();
                return comment;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool RemoveProductBought(int ProductId, string UserId)
        {
            try
            {
                DateTime now = DateTime.Now;
                ProductsBought remove = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.ProductId == ProductId && x.Time.DayOfYear == now.DayOfYear).FirstOrDefault();

                if (remove != null)
                {
                    context.ProductsBought.Remove(remove);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public string GetUserEmail(string UserId)
        {
            try
            {
                return context.Users.Find(UserId).Email;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public ApplicationUser GetUserData(string UserId)
        {
            ApplicationUser model = new ApplicationUser();

            try
            {
                ApplicationUser user = context.Users.Find(UserId);



                return model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool ChangeUser(ApplicationUser user)
        {
            try
            {
                ApplicationUser User = context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                User.City = user.City;
                User.Dateofbirth = user.Dateofbirth;
                User.Email = user.Email;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ChangeUserPicture(string UserId, string Path)
        {
            try
            {
                ApplicationUser User = context.Users.Where(x => x.Id == UserId).FirstOrDefault();


                string rootFolder = "";
                string authorsFile = "";

                if (User.UserImagePath != null)
                {
                    string PictureName = User.UserImagePath.Split("/Home/GetPicture/").Last();
                    string pathToRemove = System.IO.Path.Combine(env.ContentRootPath, "UserImages");
                    string pathToRemoveFull = System.IO.Path.Combine(pathToRemove, PictureName);

                    try
                    {
                        // Check if file exists with its full path    
                        if (File.Exists(pathToRemoveFull))
                        {
                            // If file found, delete it    
                            File.Delete(pathToRemoveFull);
                            Console.WriteLine("File deleted.");
                        }
                        else Console.WriteLine("File not found");
                    }
                    catch (IOException ioExp)
                    {
                        Console.WriteLine(ioExp.Message);
                    }
                }



                User.UserImagePath = Path;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckPictureOwner(string Path, string UserId)
        {
            try
            {
                string PathToCompare = context.Users.Find(UserId).UserImagePath;

                if (PathToCompare == Path)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<string> GetShopNames(string Name)
        {
            //try
            //{

            //    List<string> list = context.Shops.Where(x => x.Name.StartsWith(Name)).Select(x => x.Name).ToList();
            //    return list;

            //}
            //catch (Exception ex)
            //{
            //    return new List<string>();
            //}


            try
            {

                List<string> list = context.Shops.Where(x => x.Name.StartsWith(Name)).Select(x => x.Name).ToList();
                return list;

            }
            catch (Exception ex)
            {
                return new List<string>();
            }


        }






        public List<string> GetOwnerNames(string Name)
        {
            try
            {

                List<string> list = context.Users.Where(x => x.Surname.StartsWith(Name)).Select(x => x.Surname + " " + x.FirstName).ToList();
                return list;

            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        public Dictionary<string, string> GetOwnerNames2(string Name)
        {
            try
            {

                Dictionary<string, string> list = context.Users.Where(x => x.Surname.StartsWith(Name)).ToDictionary(x => x.Id, x => x.Surname + " " + x.FirstName + " " + x.PhoneNumber);
                return list;

            }
            catch (Exception ex)
            {
                return new Dictionary<string, string>();
            }
        }



        public bool AddShop(AddShopViewModel model)
        {
            try
            {
                bool checkName = context.Shops.Any(x => x.Name == model.shop.Name);

                bool checkLocalization = context.Locations.Any(x => x.Country == model.ShopLocation.Country && x.City == model.ShopLocation.City && x.Street == model.ShopLocation.Street && x.Number == model.ShopLocation.Number && x.SecondNumber == model.ShopLocation.SecondNumber);


                if (checkLocalization && checkName)
                {
                    return false;
                }
                else
                {
                    string PhoneNumber = "";
                    string Surname = "";
                    PhoneNumber = Regex.Match(model.shop.ApplicationUser.UserName, @"\d+").Value; ;
                    string[] text = model.shop.ApplicationUser.UserName.Split(' ');
                    Surname = text[0];





                    Location location = new Location();
                    location.Name = model.shop.Name;
                    model.SetLocation2(model.ShopLocation);
                    location = model.ShopLocation;

                    double Latitude = Convert.ToDouble(model.LatitudeText.Replace(".", ","));
                    double Longitude = Convert.ToDouble(model.LongitudeText.Replace(".", ","));

                    location.Latitude = Latitude;
                    location.Longitude = Longitude;
                    location.location = new NetTopologySuite.Geometries.Point(Longitude, Latitude) { SRID = 4326 };
                    context.Locations.Add(location);
                    context.SaveChanges();

                    model.shop.Location = location;
                    context.Shops.Add(model.shop);

                    ApplicationUser user = context.Users.Where(x => x.PhoneNumber == PhoneNumber && x.Surname == Surname).FirstOrDefault();

                    user.Shops.Add(model.shop);


                }




                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddProduct(AddNewProductViewModel model)
        {
            try
            {
                Product product = new Product();
                product.Name = model.Name;
                //product.Height = model.Height;
                product.Description = model.Description;
                product.Weight = model.Weight;
                product.Product_Price = model.Price;
                product.Last_ProductPrice = model.Price;
                product.Picture = model.Picture;

                context.Products.Add(product);
                context.SaveChanges();




                ///


                //AddCompany
                int CompanyId = Int32.Parse(model.Company.Substring(0, model.Company.IndexOf(" ")));
                Company company = context.Companies.Find(CompanyId);
                company.Products.Add(product);

                context.SaveChanges();

                ///


                //AddCategory


                Category category = context.Categories.Where(x => x.Name == model.Category).FirstOrDefault();

                ProductCategory prodCategory = new ProductCategory();
                prodCategory.Product = product;
                prodCategory.Category = category;
                context.SaveChanges();

                //


                //AddShop
                int ShopId = Int32.Parse(model.Shop.Substring(0, model.Shop.IndexOf(" ")));
                Shop shop = context.Shops.Find(ShopId);
                shop.Products.Add(product);
                context.SaveChanges();

                //






                context.SaveChanges();




                //Add BarCode



                Product_Code code = context.Product_Codes.Where(x => x.Code == model.Barcode).FirstOrDefault();
                if (code != null)
                {


                    code.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    Product_Code code1 = new Product_Code();
                    code1.Code = model.Barcode;
                    code1.Country = model.CodeCountry;
                    code1.ProductInfo = model.Description;
                    code1.Producer = model.Company;

                    context.Product_Codes.Add(code1);
                    context.SaveChanges();

                    code1.Products.Add(product);
                    context.SaveChanges();

                }



                //



                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<string> GetShopNamesAutocomplete(string Name)
        {
            List<string> list = new List<string>();
            try
            {
                list = context.Shops.Where(x => x.Name.StartsWith(Name)).Select(x => x.ShopId + " . " + x.Name + " " + x.Location.Country + " " + x.Location.City + " " + x.Location.Street + " " + x.Location.Number).ToList();

                return list;
            }
            catch (Exception ex)
            {
                return new List<string>();
            }



        }

        public List<string> GetCompanyNamesAutocomplete(string Name)
        {
            List<string> list = new List<string>();
            try
            {

                list = context.Companies.Where(x => x.Name.StartsWith(Name)).Select(x => x.CompanyId + " " + x.Address + " " + x.Name).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        public string CheckIfNewProductExists(string Barcode, string Shop, double Price)
        {
            string message = "";
            try
            {




                int ShopId = Int32.Parse(Shop.Substring(0, Shop.IndexOf(" "))); ;


                bool check = context.Shops.Include(x => x.Products).Where(x => x.ShopId == ShopId).FirstOrDefault().Products.Where(x => x.Product_Code.Code == Barcode && x.Product_Price == Price).Any();


                if (check)
                {
                    message = "Sklep zawiera już ten produkt w takiej cenie ";
                }


                return message;

            }
            catch (Exception ex)
            {
                return "Błąd podczas dodawania obiektu";
            }
        }
    }

}
