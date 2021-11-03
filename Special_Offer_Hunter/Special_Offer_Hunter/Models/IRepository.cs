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

namespace Special_Offer_Hunter.Models
{
    public interface IRepository
    {
        Product GetProductById(int Id);
        Product GetProductByName(string Name);
        Product GetProductByCode(string Code);
        Location GetUserLocation(string UserId);
        List<string> GetCategories();
        bool AddProductToUserShoppingCart(string UserId, ShoppingCartType type, int ProductId);
        bool RemoveProductFromShoppingCart(string UserId, ShoppingCartType type, int ProductId);
        public ShoppingCartViewModel GetShoppingCart(string UserId, ShoppingCartType type);
        List<Product> GetProductsWithSpecialOffer2(SpecialOfferViewModel offer);
        bool AddPriceToProduct(int ProductId, double Price);

        List<ProductLocation> GetProductLocationByCartType(ShoppingCartType type, string UserId);

        bool AddProduct(Product product);

        bool SaveCoordinatesAppUser(double Latitude, double Longitude, string UserId);

        public Dictionary<Product, double> GetProductsWithSpecialOffer(SpecialOfferViewModel offer);

        public bool AddStatisticsToCart(int ShoppingCartId, ShoppingCartType type, CartStatistics statisctic);



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

        public Repository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public bool AddPriceToProduct(int ProductId, double Price)
        {
            try
            {
                Product product = context.Products.Find(ProductId);
                Product_Price price = new Product_Price(Price);
                price.Products.Add(product);
                context.Product_Prices.Add(price);
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

        //public ShoppingCartViewModel GetShoppingCart(string UserId, ShoppingCartType type)
        //{

        //    ShoppingCartViewModel model = new ShoppingCartViewModel();
        //    model.type = type;
        //    model.UserId = UserId;
        //    try
        //    {
        //        ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Day).Include(x => x.Shopping_Cart_Week).Include(x => x.Shopping_Cart_Month).Include(x => x.Shopping_Cart_Year).Include(x => x.Shopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();

        //        switch (type)
        //        {
        //            case ShoppingCartType.Dzień:
        //                Shopping_Cart_Day cart = context.Shopping_Carts_Day.Include(x => x.Products).Where(x => x.Shopping_Cart_DayId == user.Shopping_Cart_Day.Shopping_Cart_DayId).FirstOrDefault();
        //                model.productList = cart.Products.ToList();
        //                break;
        //            case ShoppingCartType.Tydzień:
        //                Shopping_Cart_Week cart1 = context.Shopping_Carts_Week.Include(x => x.Products).Where(x => x.Shopping_Cart_WeekId == user.Shopping_Cart_Week.Shopping_Cart_WeekId).FirstOrDefault();
        //                model.productList = cart1.Products.ToList();
        //                break;
        //            case ShoppingCartType.Miesiąc:
        //                Shopping_Cart_Month cart2 = context.Shopping_Cart_Month.Include(x => x.Products).Where(x => x.Shopping_Cart_MonthId == user.Shopping_Cart_Month.Shopping_Cart_MonthId).FirstOrDefault();
        //                model.productList = cart2.Products.ToList();
        //                break;
        //            case ShoppingCartType.Rok:
        //                Shopping_Cart_Year cart3 = context.Shopping_Cart_Year.Include(x => x.Products).Where(x => x.Shopping_Cart_YearId == user.Shopping_Cart_Year.Shopping_Cart_YearId).FirstOrDefault();
        //                model.productList = cart3.Products.ToList();
        //                break;
        //            case ShoppingCartType.Poszukiwane:
        //                Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.Products).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Shopping_Cart_LookForId).FirstOrDefault();
        //                model.productList = cart4.Products.ToList();
        //                break;

        //        }

        //        return model;
        //    }
        //    catch (Exception ex)
        //    {
        //        return model;
        //    }
        //}


        public bool CheckDay(DateTime compare)
        {

            return DateTime.Today == compare;

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
            DateTime b = DateTime.Now;

            if (a.AddDays(7 - (int)a.DayOfWeek).Date.Equals(b.AddDays(
             7 - (int)b.DayOfWeek).Date))
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
                ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Days).Include(x => x.Shopping_Cart_Weeks).Include(x => x.Shopping_Cart_Months).Include(x => x.Shopping_Cart_Years).Include(x => x.Shopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();

                switch (type)
                {
                    case ShoppingCartType.Dzień:
                        Shopping_Cart_Day cart = context.Shopping_Carts_Day.Include(x => x.ProductShopping_Cart_Days).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_DayId == user.Shopping_Cart_Days.Last().Shopping_Cart_DayId).FirstOrDefault();
                        list = cart.ProductShopping_Cart_Days.Select(x => x.Product).ToList();



                        foreach (var item in list)
                        {

                            List<ProductsBought> listBought = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.ProductId == item.ProductId).ToList();

                            int number = 0;

                            foreach (var item2 in listBought)
                            {
                                bool check = CheckDay(item2.Time);
                                number = number + 1;
                            }

                            listDetails.Add(new ShoppingDetails() { product = item, ProductNumber = number });


                        }


                        break;
                    case ShoppingCartType.Tydzień:
                        Shopping_Cart_Week cart1 = context.Shopping_Carts_Week.Include(x => x.ProductShopping_Cart_Weeks).Where(x => x.Shopping_Cart_WeekId == user.Shopping_Cart_Weeks.Last().Shopping_Cart_WeekId).FirstOrDefault();
                        list = cart1.ProductShopping_Cart_Weeks.Select(x => x.Product).ToList();

                        foreach (var item in list)
                        {

                            List<ProductsBought> listBought = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.ProductId == item.ProductId).ToList();

                            int number = 0;

                            foreach (var item2 in listBought)
                            {
                                bool check = CheckWeek(item2.Time);
                                if (check)
                                {
                                    number = number + 1;
                                }

                            }

                            listDetails.Add(new ShoppingDetails() { product = item, ProductNumber = number });


                        }
                        break;
                    case ShoppingCartType.Miesiąc:
                        Shopping_Cart_Month cart2 = context.Shopping_Cart_Month.Include(x => x.ProductShopping_Cart_Months).Where(x => x.Shopping_Cart_MonthId == user.Shopping_Cart_Months.Last().Shopping_Cart_MonthId).FirstOrDefault();
                        list = cart2.ProductShopping_Cart_Months.Select(x => x.Product).ToList();
                        foreach (var item in list)
                        {

                            List<ProductsBought> listBought = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.ProductId == item.ProductId).ToList();

                            int number = 0;

                            foreach (var item2 in listBought)
                            {
                                bool check = CheckMonth(item2.Time);
                                if (check)
                                {
                                    number = number + 1;
                                }

                            }

                            listDetails.Add(new ShoppingDetails() { product = item, ProductNumber = number });


                        }
                        break;
                    case ShoppingCartType.Rok:
                        Shopping_Cart_Year cart3 = context.Shopping_Cart_Year.Include(x => x.ProductShopping_Cart_Years).Where(x => x.Shopping_Cart_YearId == user.Shopping_Cart_Years.Last().Shopping_Cart_YearId).FirstOrDefault();
                        list = cart3.ProductShopping_Cart_Years.Select(x => x.Product).ToList();
                        foreach (var item in list)
                        {

                            List<ProductsBought> listBought = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.ProductId == item.ProductId).ToList();

                            int number = 0;

                            foreach (var item2 in listBought)
                            {
                                bool check = CheckYear(item2.Time);

                                if (check)
                                {
                                    number = number + 1;
                                }


                            }

                            listDetails.Add(new ShoppingDetails() { product = item, ProductNumber = number });


                        }
                        break;
                    case ShoppingCartType.Poszukiwane:
                        Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.ProductShopping_Cart_LookFor).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Last().Shopping_Cart_LookForId).FirstOrDefault();
                        list = cart4.ProductShopping_Cart_LookFor.Select(x => x.Product).ToList();
                        foreach (var item in list)
                        {

                            List<ProductsBought> listBought = context.Users.Include(x => x.ProductsBought).Where(x => x.Id == UserId).FirstOrDefault().ProductsBought.Where(x => x.ProductId == item.ProductId).ToList();

                            int number = 0;

                            foreach (var item2 in listBought)
                            {

                                number = number + 1;
                            }

                            listDetails.Add(new ShoppingDetails() { product = item, ProductNumber = number });


                        }
                        break;

                }

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

        public List<Product> GetProductsWithPrice(double Price)
        {
            try
            {
                Product_Price x = context.Product_Prices.Include(x => x.Products).Where(x => x.Price == Price).FirstOrDefault();
                List<Product> list = context.Product_Prices.Include(x => x.Products).Where(x => x.Price == Price).AsQueryable().ToList().SelectMany(x => x.Products).ToList();
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
        public static Expression<Func<Product, double>> OrderDescending2Price = d => d.Product_Price.Price;

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

        //public bool AddProductToUserShoppingCart(string UserId, ShoppingCartType type, int ProductId)
        //{
        //    try
        //    {
        //        Product product = context.Products.Find(ProductId);
        //        int CartId = 0;

        //        ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Day).Include(x => x.Shopping_Cart_Week).Include(x => x.Shopping_Cart_Month).Include(x => x.Shopping_Cart_Year).Include(x => x.Shopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();

        //        switch (type)
        //        {
        //            case ShoppingCartType.Dzień:


        //                if (user.Shopping_Cart_Day == null)
        //                {
        //                    Shopping_Cart_Day cartDay = new Shopping_Cart_Day();
        //                    context.Shopping_Carts_Day.Add(cartDay);
        //                    context.SaveChanges();
        //                    CartId = cartDay.Shopping_Cart_DayId;
        //                    ApplicationUser userX = context.Users.Find(UserId);
        //                    Shopping_Cart_Day day = context.Shopping_Carts_Day.Find(CartId);
        //                    userX.Shopping_Cart_Day = day;
        //                    context.SaveChanges();
        //                }

        //                Shopping_Cart_Day cart = context.Shopping_Carts_Day.Include(x => x.Products).Where(x => x.Shopping_Cart_DayId == user.Shopping_Cart_Day.Shopping_Cart_DayId).FirstOrDefault();

        //                if (!cart.Products.Any(x => x.ProductId == ProductId))
        //                {
        //                    cart.Products.Add(product);
        //                    context.SaveChanges();
        //                }


        //                break;
        //            case ShoppingCartType.Tydzień:

        //                if (user.Shopping_Cart_Week == null)
        //                {
        //                    Shopping_Cart_Week cartWeek = new Shopping_Cart_Week();
        //                    context.Shopping_Carts_Week.Add(cartWeek);
        //                    context.SaveChanges();
        //                    CartId = cartWeek.Shopping_Cart_WeekId;
        //                    ApplicationUser userX = context.Users.Find(UserId);
        //                    Shopping_Cart_Week week = context.Shopping_Carts_Week.Find(CartId);
        //                    userX.Shopping_Cart_Week = week;
        //                    context.SaveChanges();
        //                }
        //                Shopping_Cart_Week cart1 = context.Shopping_Carts_Week.Include(x => x.Products).Where(x => x.Shopping_Cart_WeekId == user.Shopping_Cart_Week.Shopping_Cart_WeekId).FirstOrDefault();
        //                if (!cart1.Products.Any(x => x.ProductId == ProductId))
        //                {
        //                    cart1.Products.Add(product);
        //                    context.SaveChanges();
        //                }
        //                break;
        //            case ShoppingCartType.Miesiąc:
        //                if (user.Shopping_Cart_Month == null)
        //                {
        //                    Shopping_Cart_Month cartM = new Shopping_Cart_Month();
        //                    context.Shopping_Cart_Month.Add(cartM);
        //                    context.SaveChanges();
        //                    CartId = cartM.Shopping_Cart_MonthId;
        //                    ApplicationUser userX = context.Users.Find(UserId);
        //                    Shopping_Cart_Month day = context.Shopping_Cart_Month.Find(CartId);
        //                    userX.Shopping_Cart_Month = day;
        //                    context.SaveChanges();
        //                }
        //                Shopping_Cart_Month cart2 = context.Shopping_Cart_Month.Include(x => x.Products).Where(x => x.Shopping_Cart_MonthId == user.Shopping_Cart_Month.Shopping_Cart_MonthId).FirstOrDefault();
        //                if (!cart2.Products.Any(x => x.ProductId == ProductId))
        //                {
        //                    cart2.Products.Add(product);
        //                    context.SaveChanges();
        //                }
        //                break;
        //            case ShoppingCartType.Rok:
        //                if (user.Shopping_Cart_Year == null)
        //                {
        //                    Shopping_Cart_Year cartY = new Shopping_Cart_Year();
        //                    context.Shopping_Cart_Year.Add(cartY);
        //                    context.SaveChanges();
        //                    CartId = cartY.Shopping_Cart_YearId;
        //                    ApplicationUser userX = context.Users.Find(UserId);
        //                    Shopping_Cart_Year day = context.Shopping_Cart_Year.Find(CartId);
        //                    userX.Shopping_Cart_Year = day;
        //                    context.SaveChanges();
        //                }
        //                Shopping_Cart_Year cart3 = context.Shopping_Cart_Year.Include(x => x.Products).Where(x => x.Shopping_Cart_YearId == user.Shopping_Cart_Year.Shopping_Cart_YearId).FirstOrDefault();
        //                if (!cart3.Products.Any(x => x.ProductId == ProductId))
        //                {
        //                    cart3.Products.Add(product);
        //                    context.SaveChanges();
        //                }
        //                break;
        //            case ShoppingCartType.Poszukiwane:
        //                if (user.Shopping_Cart_LookFor == null)
        //                {
        //                    Shopping_Cart_LookFor cartL = new Shopping_Cart_LookFor();
        //                    context.Shopping_Cart_LookFor.Add(cartL);
        //                    context.SaveChanges();
        //                    CartId = cartL.Shopping_Cart_LookForId;
        //                    ApplicationUser userX = context.Users.Find(UserId);
        //                    Shopping_Cart_LookFor day = context.Shopping_Cart_LookFor.Find(CartId);
        //                    userX.Shopping_Cart_LookFor = day;
        //                    context.SaveChanges();
        //                }
        //                Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.Products).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Shopping_Cart_LookForId).FirstOrDefault();
        //                if (!cart4.Products.Any(x => x.ProductId == ProductId))
        //                {
        //                    cart4.Products.Add(product);
        //                    context.SaveChanges();
        //                }
        //                break;

        //        }






        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public bool AddProductToUserShoppingCart(string UserId, ShoppingCartType type, int ProductId)
        {
            try
            {
                Product product = context.Products.Find(ProductId);
                int CartId = 0;

                ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Days).ThenInclude(x => x.ProductShopping_Cart_Days).Include(x => x.Shopping_Cart_Weeks).ThenInclude(x => x.ProductShopping_Cart_Weeks).Include(x => x.Shopping_Cart_Months).ThenInclude(x => x.ProductShopping_Cart_Months).Include(x => x.Shopping_Cart_Years).ThenInclude(x => x.ProductShopping_Cart_Years).Include(x => x.Shopping_Cart_LookFor).ThenInclude(x => x.ProductShopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();

                switch (type)
                {
                    case ShoppingCartType.Dzień:


                        if (user.Shopping_Cart_Days.Count() == 0)
                        {
                            Shopping_Cart_Day cartDay = new Shopping_Cart_Day();
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
                    case ShoppingCartType.Tydzień:

                        if (user.Shopping_Cart_Weeks.Count() == 0)
                        {
                            Shopping_Cart_Week cartWeek = new Shopping_Cart_Week();
                            context.Shopping_Carts_Week.Add(cartWeek);
                            context.SaveChanges();
                            CartId = cartWeek.Shopping_Cart_WeekId;
                            ApplicationUser userX = context.Users.Find(UserId);
                            Shopping_Cart_Week week = context.Shopping_Carts_Week.Find(CartId);
                            userX.Shopping_Cart_Weeks.Add(week);
                            context.SaveChanges();
                        }
                        Shopping_Cart_Week cart1 = context.Shopping_Carts_Week.Include(x => x.ProductShopping_Cart_Weeks).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_WeekId == user.Shopping_Cart_Weeks.Last().Shopping_Cart_WeekId).FirstOrDefault();
                        if (!cart1.ProductShopping_Cart_Weeks.Any(x => x.ProductId == ProductId))
                        {
                            ProductShopping_Cart_Week pcd = new ProductShopping_Cart_Week();
                            Product prod = context.Products.Find(ProductId);

                            pcd.Product = prod;
                            pcd.Shopping_Cart_Week = cart1;

                            context.ProductShopping_Carts_Weeks.Add(pcd);
                            context.SaveChanges();
                        }
                        break;
                    case ShoppingCartType.Miesiąc:
                        if (user.Shopping_Cart_Months.Count() == 0)
                        {
                            Shopping_Cart_Month cartM = new Shopping_Cart_Month();
                            context.Shopping_Cart_Month.Add(cartM);
                            context.SaveChanges();
                            CartId = cartM.Shopping_Cart_MonthId;
                            ApplicationUser userX = context.Users.Find(UserId);
                            Shopping_Cart_Month day = context.Shopping_Cart_Month.Find(CartId);
                            userX.Shopping_Cart_Months.Add(day);
                            context.SaveChanges();
                        }
                        Shopping_Cart_Month cart2 = context.Shopping_Cart_Month.Include(x => x.ProductShopping_Cart_Months).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_MonthId == user.Shopping_Cart_Months.Last().Shopping_Cart_MonthId).FirstOrDefault();
                        if (!cart2.ProductShopping_Cart_Months.Any(x => x.ProductId == ProductId))
                        {
                            ProductShopping_Cart_Month pcd = new ProductShopping_Cart_Month();
                            Product prod = context.Products.Find(ProductId);

                            pcd.Product = prod;
                            pcd.Shopping_Cart_Month = cart2;

                            context.ProductShopping_Cart_Months.Add(pcd);
                            context.SaveChanges();
                        }
                        break;
                    case ShoppingCartType.Rok:
                        if (user.Shopping_Cart_Years.Count() == 0)
                        {
                            Shopping_Cart_Year cartY = new Shopping_Cart_Year();
                            context.Shopping_Cart_Year.Add(cartY);
                            context.SaveChanges();
                            CartId = cartY.Shopping_Cart_YearId;
                            ApplicationUser userX = context.Users.Find(UserId);
                            Shopping_Cart_Year day = context.Shopping_Cart_Year.Find(CartId);
                            userX.Shopping_Cart_Years.Add(day);
                            context.SaveChanges();
                        }
                        Shopping_Cart_Year cart3 = context.Shopping_Cart_Year.Include(x => x.ProductShopping_Cart_Years).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_YearId == user.Shopping_Cart_Years.Last().Shopping_Cart_YearId).FirstOrDefault();
                        if (!cart3.ProductShopping_Cart_Years.Any(x => x.ProductId == ProductId))
                        {
                            ProductShopping_Cart_Year pcd = new ProductShopping_Cart_Year();
                            Product prod = context.Products.Find(ProductId);

                            pcd.Product = prod;
                            pcd.Shopping_Cart_Year = cart3;

                            context.ProductShopping_Cart_Years.Add(pcd);
                            context.SaveChanges();
                        }
                        break;
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






        //public bool RemoveProductFromShoppingCart(string UserId, ShoppingCartType type, int ProductId)
        //{
        //    try
        //    {
        //        ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Day).Include(x => x.Shopping_Cart_Week).Include(x => x.Shopping_Cart_Month).Include(x => x.Shopping_Cart_Year).Include(x => x.Shopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();
        //        Product product = context.Products.Find(ProductId);
        //        switch (type)
        //        {
        //            case ShoppingCartType.Dzień:
        //                Shopping_Cart_Day cart = context.Shopping_Carts_Day.Find(user.Shopping_Cart_Day.Shopping_Cart_DayId);
        //                cart.Products.Remove(product);
        //                context.SaveChanges();

        //                break;
        //            case ShoppingCartType.Tydzień:
        //                Shopping_Cart_Week cart1 = context.Shopping_Carts_Week.Find(user.Shopping_Cart_Week.Shopping_Cart_WeekId);
        //                cart1.Products.Remove(product);
        //                context.SaveChanges();

        //                break;
        //            case ShoppingCartType.Miesiąc:
        //                Shopping_Cart_Month cart2 = context.Shopping_Cart_Month.Find(user.Shopping_Cart_Month.Shopping_Cart_MonthId);

        //                cart2.Products.Remove(product);
        //                context.SaveChanges();
        //                break;
        //            case ShoppingCartType.Rok:
        //                Shopping_Cart_Year cart3 = context.Shopping_Cart_Year.Find(user.Shopping_Cart_Year.Shopping_Cart_YearId);
        //                cart3.Products.Remove(product);
        //                context.SaveChanges();
        //                break;
        //            case ShoppingCartType.Poszukiwane:
        //                Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Find(user.Shopping_Cart_LookFor.Shopping_Cart_LookForId);
        //                cart4.Products.Remove(product);
        //                context.SaveChanges();
        //                break;

        //        }




        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}


        public bool RemoveProductFromShoppingCart(string UserId, ShoppingCartType type, int ProductId)
        {
            try
            {
                ApplicationUser user = context.Users.Include(x => x.Shopping_Cart_Days).Include(x => x.Shopping_Cart_Weeks).Include(x => x.Shopping_Cart_Months).Include(x => x.Shopping_Cart_Years).Include(x => x.Shopping_Cart_LookFor).Where(x => x.Id == UserId).FirstOrDefault();
                Product product = context.Products.Find(ProductId);
                switch (type)
                {
                    case ShoppingCartType.Dzień:
                        Shopping_Cart_Day cart = context.Shopping_Carts_Day.Include(x => x.ProductShopping_Cart_Days).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_DayId == user.Shopping_Cart_Days.Last().Shopping_Cart_DayId).First();

                        ProductShopping_Cart_Day r = cart.ProductShopping_Cart_Days.Where(x => x.ProductId == ProductId).FirstOrDefault();
                        cart.ProductShopping_Cart_Days.Remove(r);
                        context.SaveChanges();

                        break;
                    case ShoppingCartType.Tydzień:
                        Shopping_Cart_Week cart1 = context.Shopping_Carts_Week.Include(x => x.ProductShopping_Cart_Weeks).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_WeekId == user.Shopping_Cart_Weeks.Last().Shopping_Cart_WeekId).First();

                        ProductShopping_Cart_Week r1 = cart1.ProductShopping_Cart_Weeks.Where(x => x.ProductId == ProductId).FirstOrDefault();
                        cart1.ProductShopping_Cart_Weeks.Remove(r1);
                        context.SaveChanges();

                        break;
                    case ShoppingCartType.Miesiąc:
                        Shopping_Cart_Month cart2 = context.Shopping_Cart_Month.Include(x => x.ProductShopping_Cart_Months).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_MonthId == user.Shopping_Cart_Months.Last().Shopping_Cart_MonthId).First();

                        ProductShopping_Cart_Month r2 = cart2.ProductShopping_Cart_Months.Where(x => x.ProductId == ProductId).FirstOrDefault();
                        cart2.ProductShopping_Cart_Months.Remove(r2);
                        context.SaveChanges();
                        break;
                    case ShoppingCartType.Rok:
                        Shopping_Cart_Year cart3 = context.Shopping_Cart_Year.Include(x => x.ProductShopping_Cart_Years).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_YearId == user.Shopping_Cart_Years.Last().Shopping_Cart_YearId).First();

                        ProductShopping_Cart_Year r3 = cart3.ProductShopping_Cart_Years.Where(x => x.ProductId == ProductId).FirstOrDefault();
                        cart3.ProductShopping_Cart_Years.Remove(r3);
                        context.SaveChanges();
                        break;
                    case ShoppingCartType.Poszukiwane:
                        Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.ProductShopping_Cart_LookFor).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Last().Shopping_Cart_LookForId).First();

                        ProductShopping_Cart_LookFor r4 = cart4.ProductShopping_Cart_LookFor.Where(x => x.ProductId == ProductId).FirstOrDefault();
                        cart4.ProductShopping_Cart_LookFor.Remove(r4);
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
                    case ShoppingCartType.Tydzień:
                        Shopping_Cart_Week cart1 = context.Shopping_Carts_Week.Include(x => x.ProductShopping_Cart_Weeks).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_WeekId == user.Shopping_Cart_Weeks.Last().Shopping_Cart_WeekId).FirstOrDefault();
                        productList = cart1.ProductShopping_Cart_Weeks.Select(x => x.Product).ToList();
                        break;
                    case ShoppingCartType.Miesiąc:
                        Shopping_Cart_Month cart2 = context.Shopping_Cart_Month.Include(x => x.ProductShopping_Cart_Months).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_MonthId == user.Shopping_Cart_Months.Last().Shopping_Cart_MonthId).FirstOrDefault();
                        productList = cart2.ProductShopping_Cart_Months.Select(x => x.Product).ToList();
                        break;
                    case ShoppingCartType.Rok:
                        Shopping_Cart_Year cart3 = context.Shopping_Cart_Year.Include(x => x.ProductShopping_Cart_Years).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_YearId == user.Shopping_Cart_Years.Last().Shopping_Cart_YearId).FirstOrDefault();
                        productList = cart3.ProductShopping_Cart_Years.Select(x => x.Product).ToList();
                        break;
                    case ShoppingCartType.Poszukiwane:
                        Shopping_Cart_LookFor cart4 = context.Shopping_Cart_LookFor.Include(x => x.ProductShopping_Cart_LookFor).ThenInclude(x => x.Product).Where(x => x.Shopping_Cart_LookForId == user.Shopping_Cart_LookFor.Last().Shopping_Cart_LookForId).FirstOrDefault();
                        productList = cart4.ProductShopping_Cart_LookFor.Select(x => x.Product).ToList();
                        break;

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

        public bool AddStatisticsToCart(int ShoppingCartId, ShoppingCartType type, CartStatistics statisctic)
        {
            try
            {

                switch (type)
                {
                    case ShoppingCartType.Dzień:

                        Shopping_Cart_Day day = context.Shopping_Carts_Day.Include(x => x.Statistic).Where(x => x.Shopping_Cart_DayId == ShoppingCartId).FirstOrDefault();

                        if (day.Statistic == null)
                        {
                            day.Statistic = new CartStatistics();
                        }

                        day.Statistic = statisctic;

                        context.SaveChanges();

                        break;
                    case ShoppingCartType.Tydzień:

                        Shopping_Cart_Week week = context.Shopping_Carts_Week.Include(x => x.Statistic).Where(x => x.Shopping_Cart_WeekId == ShoppingCartId).FirstOrDefault();

                        week.Statistic = statisctic;

                        context.SaveChanges();

                        break;
                    case ShoppingCartType.Miesiąc:

                        Shopping_Cart_Month month = context.Shopping_Cart_Month.Include(x => x.Statistic).Where(x => x.Shopping_Cart_MonthId == ShoppingCartId).FirstOrDefault();

                        month.Statistic = statisctic;

                        context.SaveChanges();

                        break;
                    case ShoppingCartType.Rok:

                        Shopping_Cart_Year year = context.Shopping_Cart_Year.Include(x => x.Statistic).Where(x => x.Shopping_Cart_YearId == ShoppingCartId).FirstOrDefault();

                        year.Statistic = statisctic;

                        context.SaveChanges();

                        break;
                    case ShoppingCartType.Poszukiwane:

                        Shopping_Cart_LookFor look = context.Shopping_Cart_LookFor.Include(x => x.Statistic).Where(x => x.Shopping_Cart_LookForId == ShoppingCartId).FirstOrDefault();

                        look.Statistic = statisctic;

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
    }

}
