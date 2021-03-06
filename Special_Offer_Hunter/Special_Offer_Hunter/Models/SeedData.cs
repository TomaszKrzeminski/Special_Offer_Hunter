using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Special_Offer_Hunter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Special_Offer_Hunter.Models
{
    public class SeedData
    {

        ApplicationDbContext context;
        IRepository repository;
        public SeedData(ApplicationDbContext context, IRepository repo)
        {
            this.context = context;
            repository = repo;
        }


        //public static void EnsurePopulated(IApplicationBuilder app)
        public void EnsurePopulated(/*ApplicationDbContext context*/)
        {





            void SeedRoles()
            {

                try
                {


                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == "NewUser" || r.Name == "UserRole" || r.Name == "Administrator"))
                    {

                        roleStore.CreateAsync(new IdentityRole { Name = "Administrator", NormalizedName = "Administrator" });


                        roleStore.CreateAsync(new IdentityRole { Name = "UserRole", NormalizedName = "UserRole" });



                        roleStore.CreateAsync(new IdentityRole { Name = "NewUser", NormalizedName = "NewUser" });
                    }


                    context.SaveChangesAsync();





                }
                catch (Exception ex)
                {

                }
            }

            Product SeedProducts(string Name)
            {
                Product product = new Product();
                product.Name = Name;
                context.Products.Add(product);
                return product;
            }
            void SeedCategories()
            {
                List<string> list = new List<string>() { "", "Warzywa", "Owoce", "Mrożonki", "Pieczywo", "Mięso i Wędliny", "Konserwy", "Przyprawy", "Sosy", "Napoje", "Nabiał", "Słodycze", "Chemia domowa", "Kosmetyki", "Dla zwierząt", "Przekąski" };

                foreach (var item in list)
                {
                    context.Categories.Add(new Category() { Name = item });
                    context.SaveChanges();
                }
            }

            void SeedLocalization(string Name, double Latitude, double Longitude, string PostalCode, string Country, string City, string Street, int Number, string SecondNumber)
            {

                Location location = new Location();
                location.Name = Name;
                location.Country = Country;
                location.Latitude = Latitude;
                location.Longitude = Longitude;

                location.PostalCode = PostalCode;
                location.Country = Country;
                location.City = City;
                location.Street = Street;
                location.Number = Number;
                location.SecondNumber = SecondNumber;


                location.location = new NetTopologySuite.Geometries.Point(Longitude, Latitude) { SRID = 4326 };

                context.Locations.Add(location);
                context.SaveChanges();
            }

            int SeedCode(string Code, string CodeType, string Country, string Producer, string ProductInfo)
            {
                Product_Code productCode = new Product_Code();
                productCode.Code = Code;
                productCode.CodeType = CodeType;
                productCode.Country = Country;
                productCode.Producer = Producer;
                productCode.ProductInfo = ProductInfo;

                context.Product_Codes.Add(productCode);
                context.SaveChanges();
                return productCode.Product_CodeId;

            }

            void SeedAddCodeToProduct(string productName, string BarCode)
            {
                Product_Code pc = context.Product_Codes.Where(x => x.Code == BarCode).FirstOrDefault();
                Product product = context.Products.Where(x => x.Name == productName).FirstOrDefault();

                product.Product_Code = pc;
                context.SaveChanges();

            }


            void SeedAddCodeToProduct2(int ProductId, int BarCodeId)
            {
                Product_Code pc = context.Product_Codes.Where(x => x.Product_CodeId == BarCodeId).FirstOrDefault();
                Product product = context.Products.Where(x => x.ProductId == ProductId).FirstOrDefault();
                pc.Products.Add(product);
                context.SaveChanges();

            }


            void SeedAdmin(string Name, string Surname, string Sex, string City, string Email, DateTime Dateofbirth)
            {


                try
                {
                    DateTime Now = DateTime.Now;
                    TimeSpan ts = Now - Dateofbirth;
                    int age = ts.Days / 365;

                    var User = new ApplicationUser()
                    {

                        Email = Email,
                        FirstName = Name,
                        Surname = Surname,
                        City = City,
                        Dateofbirth = Dateofbirth,
                        UserName = Email,
                        EmailConfirmed = false,
                        LockoutEnabled = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = Email.ToUpper(),
                        NormalizedUserName = Email.ToUpper(),
                    };

                    if (!context.Users.Any(u => u.UserName == User.UserName))
                    {
                        var password = new PasswordHasher<ApplicationUser>();
                        var hashed = password.HashPassword(User, "Sekret123@");
                        User.PasswordHash = hashed;
                        UserStore<ApplicationUser> userStore;

                        userStore = new UserStore<ApplicationUser>(context);

                        userStore.CreateAsync(User).Wait();
                        ////////
                        Claim claim = new Claim(ClaimTypes.Email, User.Email);
                        List<Claim> claims = new List<Claim>();
                        claims.Add(claim);
                        userStore.AddClaimsAsync(User, claims);
                        userStore.AddToRoleAsync(User, "Administrator").Wait();

                    }
                    context.SaveChanges();

                }
                catch (Exception ex)
                {

                }






            }

            void SeedUser(string Name, string Surname, string Sex, string City, string Email, DateTime Dateofbirth)
            {


                try
                {
                    DateTime Now = DateTime.Now;
                    TimeSpan ts = Now - Dateofbirth;
                    int age = ts.Days / 365;

                    var User = new ApplicationUser()
                    {

                        FirstName = Name,
                        Email = Email,
                        Surname = Surname,
                        //Sex = Sex,
                        City = City,
                        Dateofbirth = Dateofbirth,
                        UserName = Email,
                        EmailConfirmed = false,
                        LockoutEnabled = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        NormalizedEmail = Email.ToUpper(),
                        NormalizedUserName = Email.ToUpper(),
                    };

                    if (!context.Users.Any(u => u.UserName == User.UserName))
                    {
                        var password = new PasswordHasher<ApplicationUser>();
                        var hashed = password.HashPassword(User, "Sekret123@");
                        User.PasswordHash = hashed;
                        UserStore<ApplicationUser> userStore;

                        userStore = new UserStore<ApplicationUser>(context);

                        //userStore.CreateAsync(User).Wait();
                        userStore.CreateAsync(User).Wait();
                        ////////
                        Claim claim = new Claim(ClaimTypes.Email, User.Email);
                        List<Claim> claims = new List<Claim>();
                        claims.Add(claim);
                        userStore.AddClaimsAsync(User, claims).Wait();
                        userStore.AddToRoleAsync(User, "UserRole").Wait();

                    }
                    context.SaveChanges();

                }
                catch (Exception ex)
                {

                }






            }

            void SeedShop(Shop shop, string LocationName)
            {
                Shop x = shop;
                context.Add(x);
                context.SaveChanges();
                Shop y = context.Shops.Find(x.ShopId);
                Location location = context.Locations.Where(x => x.Name == LocationName).FirstOrDefault();
                y.Location = location;
                context.SaveChanges();

            }
            void SeedAddProductToCategory(Product p, string CategoryName)
            {
                Product product = context.Products.Find(p.ProductId);
                Category cat = context.Categories.Where(x => x.Name == CategoryName).First();
                ProductCategory pc = new ProductCategory() { CategoryId = cat.CategoryId, Category = cat, ProductId = product.ProductId, Product = product };
                cat.ProductCategory.Add(pc);
                product.ProductCategory.Add(pc);
                context.SaveChanges();


            }
            void SeedCompany(Company company)
            {
                company.Address = "Seed Example";
                context.Companies.Add(company);
                context.SaveChanges();

            }

            void SeedProductToCompany(int ProductId, string CompanyName)
            {

                Product product = context.Products.Find(ProductId);
                Company company = context.Companies.Where(x => x.Name == CompanyName).FirstOrDefault();
                company.Products.Add(product);
                context.SaveChanges();

            }

            if (context.Database.EnsureCreated())
            {
                if (!context.Users.Any())
                {

                    SeedRoles();

                    SeedAdmin("ADMIN", "ADMIN", "Mężczyzna", "Świecie", "ADMIN@gmail.com", new DateTime(1985, 8, 21));

                    SeedUser("Tomek", "Kowalski", "Mężczyzna", "Świecie", "zdalnerepo1985@gmail.com", new DateTime(1985, 8, 21));
                    SeedUser("Ada", "Kowalska", "Kobieta", "Świecie", "U2@gmail.com", new DateTime(1985, 8, 21));
                    SeedUser("Janusz", "Świerczyński", "Mężczyzna", "Świecie", "U3@gmail.com", new DateTime(1950, 8, 21));
                    SeedUser("Martyna", "Kawka", "Kobieta", "Bydgoszcz", "U4@gmail.com", new DateTime(1990, 8, 21));
                    SeedUser("Jacek", "Szmelter", "Mężczyzna", "Chełmno", "U5@gmail.com", new DateTime(1985, 8, 21));
                    SeedUser("Mariusz", "Brown", "Mężczyzna", "Chełmno", "U6@gmail.com", new DateTime(1975, 8, 21));
                    SeedUser("Adek", "Teller", "Mężczyzna", "Chełmno", "U7@gmail.com", new DateTime(1980, 8, 21));
                    SeedUser("Lolek", "Goldman", "Mężczyzna", "Bydgoszcz", "U8@gmail.com", new DateTime(1990, 8, 21));
                    SeedUser("Weronika", "Rossati", "Kobieta", "Świecie", "U9@gmail.com", new DateTime(1999, 8, 21));
                    SeedUser("Ania", "Przybylska", "Kobieta", "Bydgoszcz", "U10@gmail.com", new DateTime(2001, 8, 21));
                    SeedUser("Karolina", "Świerczyński", "Kobieta", "Świecie", "U11@gmail.com", new DateTime(1950, 8, 21));

                    SeedLocalization("Polo Market", 53.4071, 18.4333, "86-100", "Poland", "Świecie", "Wojska Polskiego", 83, "Brak");
                    SeedLocalization("Biedronka Kościuszki", 53.41, 18.45, "86-100", "Poland", "Świecie", "Sikorskiego", 2, "Brak");
                    SeedLocalization("Biedronka Pks", 53.40, 18.43, "86-100", "Poland", "Świecie", "Wojska Polskiego", 90, "Brak");
                    SeedLocalization("Platan", 53.40, 18.45, "86-100", "Poland", "Świecie", "Duży rynek", 4, "Brak");
                    SeedLocalization("Tesco", 53.4055, 18.4369, "86-100", "Poland", "Świecie", "Cukrowników", 2, "Brak");
                    SeedLocalization("Alex", 53.4121, 18.4512, "86-100", "Poland", "Świecie", "Kościuszki", 83, "Brak");
                    SeedLocalization("FocusBydgoszcz", 53.123, 18.01, "86-100", "Poland", "Bydgoszcz", "Centrum", 83, "Brak");
                    SeedLocalization("AlfaGrudziądz", 53.484, 18.745, "86-100", "Poland", "Grudziądz", "Centrum", 83, "Brak");
                    SeedCategories();

                    List<string> listCompany = new List<string>() { "Monster", "Nestle", "Winterfresh", "Blend-a-Med", "Vitalsss", "Lech", "Inka" };


                    foreach (var item in listCompany)
                    {
                        SeedCompany(new Company() { Name = item });
                    }



                    void SeedProductsForShop(string ShopName, List<double> Prices, List<bool> SpecialOffer)
                    {
                        Product p1 = SeedProducts("Winterfresh Original Guma Do Ucia Bez Cukru 35 G");
                        int id = SeedCode("4009900382250", "EAN13", "", "Winterfresh", "Winterfresh Original Guma Do Ucia Bez Cukru 35 G");
                        SeedAddCodeToProduct2(p1.ProductId, id);
                        //SeedAddCodeToProduct("Winterfresh Original Guma Do Ucia Bez Cukru 35 G", "4009900382250");
                        SeedAddProductToCategory(p1, "Przekąski");
                        SeedProductToCompany(p1.ProductId, "Winterfresh");

                        Product p2 = SeedProducts("Blend-a-Med 3D White Fresh Cool Water Wybielajca");
                        int id1 = SeedCode("4015600620035", "EAN13", "", "Winterfresh", "Blend-a-Med 3D White Fresh Cool Water Wybielajca");
                        SeedAddCodeToProduct2(p2.ProductId, id1);
                        //SeedAddCodeToProduct("Winterfresh Original Guma Do Ucia Bez Cukru 35 G", "4015600620035");
                        SeedAddProductToCategory(p2, "Kosmetyki");
                        SeedProductToCompany(p2.ProductId, "Blend-a-Med");

                        Product p3 = SeedProducts("Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)");
                        int id2 = SeedCode("5906204007874", "EAN13", "", "Vitalsss plus", "Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)");
                        SeedAddCodeToProduct2(p3.ProductId, id2);
                        ////SeedAddCodeToProduct("Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)", "5906204007874");
                        SeedAddProductToCategory(p3, "Napoje");
                        SeedProductToCompany(p3.ProductId, "Vitalsss");

                        Product p4 = SeedProducts("Kawa Inka 200G");
                        int id3 = SeedCode("5901154041497", "EAN13", "", "Inka", "Kawa Inka 200G");
                        //SeedAddCodeToProduct("Kawa Inka 200G", "5901154041497");
                        SeedAddCodeToProduct2(p4.ProductId, id3);
                        SeedAddProductToCategory(p4, "Napoje");
                        SeedProductToCompany(p4.ProductId, "Inka");

                        Product p5 = SeedProducts("Lech-shandy-500ml-poland");
                        int id4 = SeedCode("5901359034560", "EAN13", "", "LECH", "Lech - shandy - 500ml - poland");
                        SeedAddCodeToProduct2(p5.ProductId, id4);
                        //SeedAddCodeToProduct("Lech-shandy-500ml-poland", "5901359034560");
                        SeedAddProductToCategory(p5, "Napoje");
                        SeedProductToCompany(p5.ProductId, "Lech");


                        List<Product> list = new List<Product>() { p1, p2, p3, p4, p5 };
                        SeedShop(new Shop() { Name = ShopName }, ShopName);
                        for (int i = 0; i < 5; i++)
                        {

                            Product product = list[i];
                            //Product_Price price = new Product_Price(Prices[i], SpecialOffer[i], "");
                            //price.Products.Add(product);
                            //context.Product_Prices.Add(price);
                            product.Product_Price = Prices[i];
                            product.SpecialOffer = SpecialOffer[i];
                            context.SaveChanges();

                        }

                        for (int i = 0; i < 5; i++)
                        {

                            Shop shop = context.Shops.Where(x => x.Name == ShopName).FirstOrDefault();
                            Product product1 = list[i];
                            shop.Products.Add(product1);
                            context.SaveChanges();

                        }


                    }

                    SeedProductsForShop("Polo Market", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { false, false, false, false, false });


                    SeedProductsForShop("Biedronka Kościuszki", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { true, true, true, true, true });


                    SeedProductsForShop("Biedronka Pks", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { true, true, true, true, true });


                    SeedProductsForShop("Platan", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { false, false, false, false, false });

                    SeedProductsForShop("Tesco", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { false, false, false, false, false });


                    SeedProductsForShop("Alex", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { false, false, false, false, false });


                    SeedProductsForShop("FocusBydgoszcz", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { false, false, false, false, false });

                    SeedProductsForShop("AlfaGrudziądz", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { true, true, true, true, true });


                }
            }













        }
    }
}
