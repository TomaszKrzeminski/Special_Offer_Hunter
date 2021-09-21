using Microsoft.EntityFrameworkCore;
using Special_Offer_Hunter.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Special_Offer_Hunter.Models
{
    public interface IRepository
    {
        Product GetProductById(int Id);
        Product GetProductByName(string Name);
        Product GetProductByCode(string Code);

        List<Product> GetProductsWithSpecialOffer(SpecialOfferViewModel offer);
        bool AddPriceToProduct(int ProductId, double Price);

        bool AddProduct(Product product);







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

        public List<Product> GetProductsWithSpecialOffer(SpecialOfferViewModel offer)
        {
            try
            {
                List<Shop> shops = context.Shops.ToList();
                List<Product> list = new List<Product>();

                foreach (var s in shops)
                {
                    list = context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Where(x => x.ShopId == s.ShopId).FirstOrDefault().Products.Where(x=>x.ProductCategory.Any(x=>x.Category.Name==offer.Category)).ToList();
                }

                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
