using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //string usersJson = File.ReadAllText("../../../Datasets/users.json");
            //ImportUsers(db, usersJson);

            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //ImportProducts(db, productsJson);

            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //ImportCategories(db, categoriesJson);

            //string categoryProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //ImportCategoryProducts(db, categoryProductsJson);

            Console.WriteLine(GetUsersWithProducts(db));
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold product with a buyer. Order them in descending order by the number of sold products with a buyer. Select only their first and last name, age and for each product - name and price. Ignore all null values.

            var users = new
            {
                usersCount = context.Users.Where(x => x.ProductsSold.Any(p => p.BuyerId != null)).Count(),

                users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(p => p.BuyerId != null).Count(),
                        products = x.ProductsSold.Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList()
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var usersToJson = JsonConvert.SerializeObject(users, Formatting.Indented, settings);
            return usersToJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            //Get all categories. Order them in descending order by the category’s products count. For each category select its name, the number of products, the average price of those products (rounded to second digit after the decimal separator) and the total revenue (total price sum and rounded to second digit after the decimal separator) of those products (regardless if they have a buyer or not).

            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = $"{x.CategoryProducts.Average(p => p.Product.Price):F2}",
                    totalRevenue = $"{x.CategoryProducts.Sum(p => p.Product.Price):F2}"
                })
                .ToList();

            var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return categoriesJson;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold item with a buyer. Order them by last name, then by first name. Select the person's first and last name. For each of the sold products (products with buyers), select the product's name, price and the buyer's first and last name.
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p=>p.BuyerId != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(b=>b.BuyerId != null)
                    .Select(p => new {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .ToList();

            var usersJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            return usersJson;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {

            //Get all products in a specified price range:  500 to 1000(inclusive).Order them by price(from lowest to highest).Select only the product name, price and the full name of the seller.Export the result to JSON.
            var products = context.Products
               .Where(x => x.Price <= 1000 && x.Price >= 500)
               .OrderBy(x => x.Price)
               .Select(x => new
               {
                   name = x.Name,
                   price = x.Price,
                   seller = x.Seller.FirstName + " " + x.Seller.LastName
               })
               .ToList();

            var productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsJson;
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(config);
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var dtoCategoryProduct = JsonConvert.DeserializeObject<IEnumerable<CategoryProductDto>>(inputJson);
            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProduct);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(inputJson)
                .Where(x => x.Name != null);

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count()}";
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {dtoUsers.Count()}";
        }
    }
}