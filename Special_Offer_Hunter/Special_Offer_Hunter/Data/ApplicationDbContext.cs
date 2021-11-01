using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Special_Offer_Hunter.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace Special_Offer_Hunter.Data
{



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = aspnet - Special_Offer_Hunter - EAAB85F3 - 59A1 - 41C1 - 8B82 - CE4BE46652E7; Trusted_Connection = True; MultipleActiveResultSets = true", x => x.UseNetTopologySuite());


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.

            builder.Entity<Shop>()
            .HasOne<Location>(s => s.Location)
            .WithOne(ad => ad.Shop)
            .HasForeignKey<Location>(ad => ad.ShopLocationId);


            // builder.Entity<ApplicationUser>()
            // .HasOne<Shopping_Cart_Day>(s => s.Shopping_Cart_Day)
            // .WithOne(ad => ad.ApplicationUser)
            // .HasForeignKey<Shopping_Cart_Day>(ad => ad.DayUserId);


            // builder.Entity<ApplicationUser>()
            //            .HasOne<Shopping_Cart_Week>(s => s.Shopping_Cart_Week)
            //            .WithOne(ad => ad.ApplicationUser)
            //            .HasForeignKey<Shopping_Cart_Week>(ad => ad.WeekUserId);


            // builder.Entity<ApplicationUser>()
            //.HasOne<Shopping_Cart_Month>(s => s.Shopping_Cart_Month)
            //.WithOne(ad => ad.ApplicationUser)
            //.HasForeignKey<Shopping_Cart_Month>(ad => ad.MonthUserId);


            // builder.Entity<ApplicationUser>()
            //.HasOne<Shopping_Cart_Year>(s => s.Shopping_Cart_Year)
            //.WithOne(ad => ad.ApplicationUser)
            //.HasForeignKey<Shopping_Cart_Year>(ad => ad.YearUserId);

            // builder.Entity<ApplicationUser>()
            //.HasOne<Shopping_Cart_LookFor>(s => s.Shopping_Cart_LookFor)
            //.WithOne(ad => ad.ApplicationUser)
            //.HasForeignKey<Shopping_Cart_LookFor>(ad => ad.LookForUserId);



            builder.Entity<Shopping_Cart_Day>()
            .HasOne<CartStatistics>(s => s.Statistic)
            .WithOne(ad => ad.Shopping_Cart_Day)
            .HasForeignKey<CartStatistics>(ad => ad.StatisticOfCartId);

            builder.Entity<Shopping_Cart_Week>()
           .HasOne<CartStatistics>(s => s.Statistic)
           .WithOne(ad => ad.Shopping_Cart_Week)
           .HasForeignKey<CartStatistics>(ad => ad.StatisticOfCartId);

            builder.Entity<Shopping_Cart_Month>()
           .HasOne<CartStatistics>(s => s.Statistic)
           .WithOne(ad => ad.Shopping_Cart_Month)
           .HasForeignKey<CartStatistics>(ad => ad.StatisticOfCartId);

            builder.Entity<Shopping_Cart_Month>()
           .HasOne<CartStatistics>(s => s.Statistic)
           .WithOne(ad => ad.Shopping_Cart_Month)
           .HasForeignKey<CartStatistics>(ad => ad.StatisticOfCartId);

            builder.Entity<Shopping_Cart_Year>()
           .HasOne<CartStatistics>(s => s.Statistic)
           .WithOne(ad => ad.Shopping_Cart_Year)
           .HasForeignKey<CartStatistics>(ad => ad.StatisticOfCartId);

            builder.Entity<Shopping_Cart_LookFor>()
           .HasOne<CartStatistics>(s => s.Statistic)
           .WithOne(ad => ad.Shopping_Cart_LookFor)
           .HasForeignKey<CartStatistics>(ad => ad.StatisticOfCartId);




            builder.Entity<ProductCategory>().HasKey(sc => new { sc.ProductId, sc.CategoryId });

            builder.Entity<ProductShopping_Cart_Day>().HasKey(sc => new { sc.ProductId, sc.Shopping_Cart_DayId });
            builder.Entity<ProductShopping_Cart_Week>().HasKey(sc => new { sc.ProductId, sc.Shopping_Cart_WeekId });
            builder.Entity<ProductShopping_Cart_Month>().HasKey(sc => new { sc.ProductId, sc.Shopping_Cart_MonthId });
            builder.Entity<ProductShopping_Cart_Year>().HasKey(sc => new { sc.ProductId, sc.Shopping_Cart_YearId });
            builder.Entity<ProductShopping_Cart_LookFor>().HasKey(sc => new { sc.ProductId, sc.Shopping_Cart_LookForId });



        }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product_Price> Product_Prices { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CartStatistics> CartStatistics { get; set; }

        public DbSet<ProductShopping_Cart_Day> ProductShopping_Carts_Days { get; set; }
        public DbSet<ProductShopping_Cart_Week> ProductShopping_Carts_Weeks { get; set; }
        public DbSet<ProductShopping_Cart_Month> ProductShopping_Cart_Months { get; set; }
        public DbSet<ProductShopping_Cart_Year> ProductShopping_Cart_Years { get; set; }
        public DbSet<ProductShopping_Cart_LookFor> ProductShopping_Cart_LookFor { get; set; }


        public DbSet<Shopping_Cart_Day> Shopping_Carts_Day { get; set; }
        public DbSet<Shopping_Cart_Week> Shopping_Carts_Week { get; set; }
        public DbSet<Shopping_Cart_Month> Shopping_Cart_Month { get; set; }
        public DbSet<Shopping_Cart_Year> Shopping_Cart_Year { get; set; }
        public DbSet<Shopping_Cart_LookFor> Shopping_Cart_LookFor { get; set; }






        public DbSet<Product_Code> Product_Codes { get; set; }
        public DbSet<Shop_Rank> Shop_Ranks { get; set; }
        public DbSet<Product_Rank> Product_Ranks { get; set; }
        public DbSet<Product_Comment> Product_Comments { get; set; }
        public DbSet<Shop_Comment> Shop_Comments { get; set; }







    }
}
