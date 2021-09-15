using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Special_Offer_Hunter.Models;

namespace Special_Offer_Hunter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
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


            builder.Entity<Product>()
            .HasOne<Product_Code>(s => s.Product_Code)
            .WithOne(ad => ad.Product)
            .HasForeignKey<Product_Code>(ad => ad.ProductCodeId);
        }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Shopping_Cart_Day> Shopping_Cart_Day { get; set; }
        public DbSet<Shopping_Cart_Week> Shopping_Cart_Week { get; set; }

        public DbSet<Product_Code> Product_Code { get; set; }      
        public DbSet<Shop_Rank> Shop_Rank { get; set; }
        public DbSet<Product_Rank> Product_Rank { get; set; }
        public DbSet<Product_Comment> Product_Comment { get; set; }
        public DbSet<Shop_Comment> Shop_Comment { get; set; }







    }
}
