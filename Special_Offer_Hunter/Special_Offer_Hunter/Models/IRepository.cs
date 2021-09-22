using Microsoft.EntityFrameworkCore;
using Special_Offer_Hunter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
                //                string Name = "";


                //                static Expression<Func<Shop, bool>>
                //              SearchShop(string Name)
                //                {
                //                    return (Shop s) => s.Name == Name;


                //                }


                //                static Expression<Func<Shop, bool>>
                //              SearchShops(string Name)
                //                {
                //                    return (Shop s) => true;
                //                }



                //                Expression<Func<Shop, bool>> SearchShopX;





                //                static Expression<Func<Product, bool>>
                //SearchProductByCategory(string Category)
                //                {
                //                    return (Product c) => c.ProductCategory.Any(x => x.Category.Name == Category);
                //                }

                //                static Expression<Func<Product, bool>>
                //SearchProductByCategoryAll(string Category)
                //                {
                //                    return (Product c) => true;
                //                }


                //                static Expression<Func<Product, bool>>
                //SearchProductByProductName(string productName)
                //                {
                //                    return (Product c) => c.Name==productName;
                //                }

                //                static Expression<Func<Product, bool>>
                //SearchProductByProductNameAll(string productName)
                //                {
                //                    return (Product c) => true;
                //                }


                //                static Expression<Func<Product, bool>>
                //SearchProductByPriceHigher(double productPrice)
                //                {
                //                    return (Product c) => c.Product_Price.Price >productPrice;
                //                }

                //                static Expression<Func<Product, bool>>
                //SearchProductByPriceLower(double productPrice)
                //                {
                //                    return (Product c) => c.Product_Price.Price < productPrice;
                //                }

                //                static Expression<Func<Product, bool>>
                //SearchProductByPriceAll(double productPrice)
                //                {
                //                    return (Product c) => true;
                //                }


               


                //List<Product> listOfProducts= context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Where(SearchShop("Tesco")).FirstOrDefault().Products.AsQueryable().Where(SearchProductByCategory("Przekąski")).Where(SearchProductByProductName(offer.ProductName)).Where(SearchProductByPriceAll(100)).ToList();

                
                    //list = context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Where(SearchShop(Name)).FirstOrDefault().Products.Where(x=>x.ProductCategory.Any(x=>x.Category.Name==offer.Category)).ToList();
                List<Product>   listProd = context.Shops.Include(x => x.Products).ThenInclude(x => x.ProductCategory).Include(x => x.Products).ThenInclude(x => x.Product_Price).Where(offer.SearchShop).FirstOrDefault().Products.AsQueryable().Where(offer.SearchProductByCategory).Where(offer.SearchProductByProductName).Where(offer.SearchProductByPrice).ToList();
                    list.AddRange(listProd);
               

                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
