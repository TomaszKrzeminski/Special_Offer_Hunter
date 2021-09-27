using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Special_Offer_Hunter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Special_Offer_Hunter.Models
{
    public  class SeedData
    {

        ApplicationDbContext context;
        IRepository repository;
        public SeedData(ApplicationDbContext context, IRepository repo)
        {
            this.context = context;
            repository = repo;
        }


        //public static void EnsurePopulated(IApplicationBuilder app)
        public  void EnsurePopulated(/*ApplicationDbContext context*/)
        {


            


         void SeedRoles()
            {

                try
                {                   


                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == "NewUser"||r.Name=="UserRole"||r.Name=="Administrator"))
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
                List<string> list = new List<string>() { "Warzywa", "Owoce","Mrożonki","Pieczywo","Mięso i Wędliny","Konserwy","Przyprawy","Sosy","Napoje","Nabiał","Słodycze","Chemia domowa","Kosmetyki","Dla zwierząt","Przekąski" };

                foreach (var item in list)
                {
                    context.Categories.Add(new Category() { Name = item });
                    context.SaveChanges();
                }
            }
        
         void SeedLocalization(string Name,double Latitude,double Longitude, string PostalCode, string Country, string City, string Street, int Number, string SecondNumber)
           {
                //Location location = new Location();
                //location.Name = Name;
                //location.Country = Country;
                //location.Latitude = Latitude;
                //location.Longitude = Longitude;
                //location.PostalCode = PostalCode;
                //location.Country = Country;
                //location.City = City;
                //location.Street = Street;
                //location.Number = Number;
                //location.SecondNumber = SecondNumber;
                //context.Locations.Add(location);
                //context.SaveChanges();


                ///////////
                ///



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

         void SeedCode(string Code,string CodeType,string Country,string Producer,string ProductInfo)
            {
                Product_Code productCode = new Product_Code();
                productCode.Code = Code;
                productCode.CodeType = CodeType;
                productCode.Country = Country;
                productCode.Producer = Producer;
                productCode.ProductInfo = ProductInfo;

                context.Product_Codes.Add(productCode);
                context.SaveChanges();


            }

         void SeedAddCodeToProduct(string productName,string BarCode)
            {
                Product_Code pc = context.Product_Codes.Where(x => x.Code == BarCode).FirstOrDefault();
                Product product = context.Products.Where(x => x.Name == productName).FirstOrDefault();

                product.Product_Code = pc;
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

         void SeedShop(Shop shop,string LocationName)
            {
                Shop x = shop;
                context.Add(x);
                context.SaveChanges();
                Shop y = context.Shops.Find(x.ShopId);
                Location location = context.Locations.Where(x => x.Name == LocationName).FirstOrDefault();
                y.Location = location;
                context.SaveChanges();

            }                 
         void SeedAddProductToCategory(Product p,string CategoryName)
            {
                Product product = context.Products.Find(p.ProductId);
              Category cat=  context.Categories.Where(x => x.Name == CategoryName).First();
                ProductCategory pc = new ProductCategory() {CategoryId=cat.CategoryId, Category = cat,ProductId=product.ProductId, Product = product };
                cat.ProductCategory.Add(pc);
                product.ProductCategory.Add(pc);
                context.SaveChanges();


            }
         

            if ( context.Database.EnsureCreated())
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

                    SeedLocalization("Polo Market", 53.40d, 18.43d, "86-100", "Poland", "Świecie", "Wojska Polskiego", 83, "Brak");
                    SeedLocalization("Biedronka Kościuszki", 53.41d, 18.45d, "86-100", "Poland", "Świecie", "Sikorskiego", 2, "Brak");
                    SeedLocalization("Biedronka Pks", 53.40d, 18.43d, "86-100", "Poland", "Świecie", "Wojska Polskiego", 90, "Brak");
                    SeedLocalization("Platan", 53.40d, 18.45d, "86-100", "Poland", "Świecie", "Duży rynek", 4, "Brak");
                    SeedLocalization("Tesco", 53.40d, 18.43d, "86-100", "Poland", "Świecie", "Cukrowników", 2, "Brak");
                    SeedLocalization("Alex", 53.41d, 18.45d, "86-100", "Poland", "Świecie", "Kościuszki", 83, "Brak");
                    SeedCategories();


                  void SeedProductsForShop(string ShopName,List<double> Prices,List<bool> SpecialOffer)
                    {
                      Product p1=   SeedProducts("Winterfresh Original Guma Do Ucia Bez Cukru 35 G");
                    SeedCode("4009900382250", "EAN13", "", "Winterfresh", "Winterfresh Original Guma Do Ucia Bez Cukru 35 G");
                    SeedAddCodeToProduct("Winterfresh Original Guma Do Ucia Bez Cukru 35 G", "4009900382250");
                        SeedAddProductToCategory(p1,"Przekąski" );

                        Product p2 = SeedProducts("Blend-a-Med 3D White Fresh Cool Water Wybielajca");
                    SeedCode("4015600620035", "EAN13", "", "Winterfresh", "Blend-a-Med 3D White Fresh Cool Water Wybielajca");
                    SeedAddCodeToProduct("Winterfresh Original Guma Do Ucia Bez Cukru 35 G", "4015600620035");
                        SeedAddProductToCategory(p2,"Kosmetyki" );

                        Product p3 = SeedProducts("Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)");
                    SeedCode("5906204007898", "EAN13", "", "Vitalsss plus", "Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)");
                    SeedAddCodeToProduct("Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)", "5906204007898");
                        SeedAddProductToCategory(p3, "Napoje");

                        Product p4 = SeedProducts("Kawa Inka 200G");
                    SeedCode("5901154041497", "EAN13", "", "Inka", "Kawa Inka 200G");
                    SeedAddCodeToProduct("Kawa Inka 200G", "5901154041497");
                        SeedAddProductToCategory(p4, "Napoje");

                        Product p5 = SeedProducts("Lech-shandy-500ml-poland");
                    SeedCode("5901359034560", "EAN13", "", "LECH", "Lech - shandy - 500ml - poland");
                    SeedAddCodeToProduct("Lech-shandy-500ml-poland", "5901359034560");
                        SeedAddProductToCategory(p5, "Napoje");



                        List<Product> list = new List<Product>() { p1, p2, p3, p4, p5 };
                        SeedShop(new Shop() { Name = ShopName }, ShopName);
                        for (int i = 0; i < 5; i++)
                        {

                            Product product = list[i];
                            Product_Price price = new Product_Price(Prices[i], SpecialOffer[i], "");
                            price.Products.Add(product);
                            context.Product_Prices.Add(price);
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






                    SeedProductsForShop("Polo Market",new List<double>(){11,9,4,15,3 },new List<bool>() {true,true,true,true,true });

                    //SeedShop(new Shop() {Name="Polo Market" }, "Polo Market");
                    //SeedAddProductToShop("Polo Market", "Winterfresh Original Guma Do Ucia Bez Cukru 35 G",11);
                    //SeedAddProductToShop("Polo Market", "Blend-a-Med 3D White Fresh Cool Water Wybielajca",9);
                    //SeedAddProductToShop("Polo Market", "Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)",4);
                    //SeedAddProductToShop("Polo Market", "Kawa Inka 200G",15);
                    //SeedAddProductToShop("Polo Market", "Lech-shandy-500ml-poland",3);


                    SeedProductsForShop("Biedronka Kościuszki", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { false, false, false, false, false });
                    //SeedShop(new Shop() { Name = "Biedronka Kościuszki" }, "Biedronka Kościuszki");
                    //SeedAddProductToShop("Biedronka Kościuszki", "Winterfresh Original Guma Do Ucia Bez Cukru 35 G",11);
                    //SeedAddProductToShop("Biedronka Kościuszki", "Blend-a-Med 3D White Fresh Cool Water Wybielajca",9);
                    //SeedAddProductToShop("Biedronka Kościuszki", "Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)",4);
                    //SeedAddProductToShop("Biedronka Kościuszki", "Kawa Inka 200G",16);
                    //SeedAddProductToShop("Biedronka Kościuszki", "Lech-shandy-500ml-poland",3);

                    SeedProductsForShop("Biedronka Pks", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { true, true, true, true, true });
                    //SeedShop(new Shop() { Name = "Biedronka Pks" }, "Biedronka Pks");
                    //SeedAddProductToShop("Biedronka Pks", "Winterfresh Original Guma Do Ucia Bez Cukru 35 G",11);
                    //SeedAddProductToShop("Biedronka Pks", "Blend-a-Med 3D White Fresh Cool Water Wybielajca",9);
                    //SeedAddProductToShop("Biedronka Pks", "Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)",5);
                    //SeedAddProductToShop("Biedronka Pks", "Kawa Inka 200G",17);
                    //SeedAddProductToShop("Biedronka Pks", "Lech-shandy-500ml-poland",4);

                    SeedProductsForShop("Platan", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { true, false, false, false, false });
                    //SeedShop(new Shop() { Name = "Platan" }, "Platan");
                    //SeedAddProductToShop("Platan", "Winterfresh Original Guma Do Ucia Bez Cukru 35 G",12);
                    //SeedAddProductToShop("Platan", "Blend-a-Med 3D White Fresh Cool Water Wybielajca",10);
                    //SeedAddProductToShop("Platan", "Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)",6);
                    //SeedAddProductToShop("Platan", "Kawa Inka 200G",18);
                    //SeedAddProductToShop("Platan", "Lech-shandy-500ml-poland",5);

                    SeedProductsForShop("Tesco", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { false, false, false, false, true });
                    //SeedShop(new Shop() { Name = "Tesco" }, "Tesco");
                    //SeedAddProductToShop("Tesco", "Winterfresh Original Guma Do Ucia Bez Cukru 35 G",13);
                    //SeedAddProductToShop("Tesco", "Blend-a-Med 3D White Fresh Cool Water Wybielajca",11);
                    //SeedAddProductToShop("Tesco", "Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)",7);
                    //SeedAddProductToShop("Tesco", "Kawa Inka 200G",19);
                    //SeedAddProductToShop("Tesco", "Lech-shandy-500ml-poland",3);

                    SeedProductsForShop("Alex", new List<double>() { 11, 9, 4, 15, 3 }, new List<bool>() { false, true, false, true, false });
                    //SeedShop(new Shop() { Name = "Alex" }, "Alex");
                    //SeedAddProductToShop("Alex", "Winterfresh Original Guma Do Ucia Bez Cukru 35 G",14);
                    //SeedAddProductToShop("Alex", "Blend-a-Med 3D White Fresh Cool Water Wybielajca",8.6);
                    //SeedAddProductToShop("Alex", "Dwuwarstwowe tabletki musujące o smaku pomarańczowym z sokiem owocowym - Vitalsss plus - 100 g (25 x 4 g)",8);
                    //SeedAddProductToShop("Alex", "Kawa Inka 200G",20);
                    //SeedAddProductToShop("Alex", "Lech-shandy-500ml-poland",3);













                    //AddCoordinatesToUser("ADMIN@gmail.com", 00.000, 00.000);
                    //AddCoordinatesToUser("zdalnerepo1985@gmail.com", 53.409479, 18.442148);
                    //AddCoordinatesToUser("U2@gmail.com", 53.412120, 18.444637);
                    //AddCoordinatesToUser("U3@gmail.com", 53.412120, 18.444637);
                    //AddCoordinatesToUser("U4@gmail.com", 53.412120, 18.444637);
                    //AddCoordinatesToUser("U5@gmail.com", 53.412120, 18.444637);
                    //AddCoordinatesToUser("U6@gmail.com", 53.412120, 18.444637);
                    //AddCoordinatesToUser("U7@gmail.com", 53.351428, 18.432541);
                    //AddCoordinatesToUser("U8@gmail.com", 53.131409, 18.018191);
                    //AddCoordinatesToUser("U9@gmail.com", 53.416999, 18.458456);
                    //AddCoordinatesToUser("U10@gmail.com", 53.125177, 18.067801);
                    //AddCoordinatesToUser("U11@gmail.com", 53.416999, 18.458456);
                    //AddCoordinatesToUser("U12@gmail.com", 53.140677, 18.028920);



                    //AddNotificationCheckToAdmin("ADMIN@gmail.com");
                    //AddNotificationCheckToUser("zdalnerepo1985@gmail.com");
                    //AddNotificationCheckToUser("U2@gmail.com");
                    //AddNotificationCheckToUser("U3@gmail.com");
                    //AddNotificationCheckToUser("U4@gmail.com");
                    //AddNotificationCheckToUser("U5@gmail.com");
                    //AddNotificationCheckToUser("U6@gmail.com");
                    //AddNotificationCheckToUser("U7@gmail.com");
                    //AddNotificationCheckToUser("U8@gmail.com");
                    //AddNotificationCheckToUser("U9@gmail.com");
                    //AddNotificationCheckToUser("U10@gmail.com");
                    //AddNotificationCheckToUser("U11@gmail.com");
                    //AddNotificationCheckToUser("U12@gmail.com");

                    //AddEvents("Wydarzenie 1", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 11));
                    //AddEvents("Wydarzenie 2", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 12));
                    //AddEvents("Wydarzenie 3", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 13));
                    //AddEvents("Wydarzenie 4", "Chełmno", "86-200", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 14));
                    //AddEvents("Wydarzenie 5", "Chełmno", "86-200", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 15));
                    //AddEvents("Wydarzenie 6", "Chełmno", "86-200", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 16));
                    //AddEvents("Wydarzenie 7", "Grudziądz", "86-300", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 17));

                    //AddEvents("Wydarzenie 8", "Grudziądz", "86-300", "53.4072518", "18.4455253", "U3@gmail.com", new DateTime(2020, 12, 11));
                    //AddEvents("Wydarzenie 9", "Grudziądz", "86-300", "53.4072518", "18.4455253", "U3@gmail.com", new DateTime(2020, 12, 12));
                    //AddEvents("Wydarzenie 10", "Toruń", "87-100", "53.4072518", "18.4455253", "U3@gmail.com", new DateTime(2020, 12, 13));
                    //AddEvents("Wydarzenie 14", "Toruń", "87-100", "53.4072518", "18.4455253", "U4@gmail.com", new DateTime(2020, 12, 14));
                    //AddEvents("Wydarzenie 15", "Toruń", "87-100", "53.4072518", "18.4455253", "U4@gmail.com", new DateTime(2020, 12, 15));
                    //AddEvents("Wydarzenie 16", "Bydgoszcz", "85-000", "53.4072518", "18.4455253", "U4@gmail.com", new DateTime(2020, 12, 6));
                    //AddEvents("Wydarzenie 17", "Osie", "86-150", "53.4072518", "18.4455253", "U4@gmail.com", new DateTime(2020, 12, 17));

                    //AddEvents("Wydarzenie 29.11", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 11, 29));
                    //AddEvents("Wydarzenie 30.11", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 11, 30));
                    //AddEvents("Wydarzenie 1.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 1));
                    //AddEvents("Wydarzenie 2.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 2));
                    //AddEvents("Wydarzenie 3.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 3));
                    //AddEvents("Wydarzenie 6.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 6));
                    //AddEvents("Wydarzenie 7.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 7));

                    //AddEvents("Wydarzenie 2.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 2));
                    //AddEvents("Wydarzenie 3.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 3));
                    //AddEvents("Wydarzenie 10.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 10));
                    //AddEvents("Wydarzenie 13.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 13));
                    //AddEvents("Wydarzenie 14.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 14));
                    //AddEvents("Wydarzenie 15.12", "Świecie", "86-100", "53.4072518", "18.4455253", "U2@gmail.com", new DateTime(2020, 12, 15));


                }
            }



           








            //context.SaveChanges();
        }
    }
}
