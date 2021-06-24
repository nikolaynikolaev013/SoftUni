using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            ImportData(db);

            System.Console.WriteLine(GetUsersWithProducts(db));
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            // Select users who have at least 1 sold product. Order them by the number of sold products(from highest to lowest). Select only their first and last name, age, count of sold products and for each product -name and price sorted by price(descending).Take top 10 records.

            var users = new UsersAndProductsExportModel()
            {
                Count = context.Users.Where(x => x.ProductsSold.Any(ps => ps.Buyer != null)).Count(),
                Users = context.Users
                    .Where(x => x.ProductsSold.Any(ps => ps.Buyer != null))
                    .ToArray()
                    .OrderByDescending(x => x.ProductsSold.Count)
                    .Take(10)
                    .Select(x => new UsersExportModel
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        Products = new SoldProductsExportModel
                        {
                            Count = x.ProductsSold.Where(ps => ps.Buyer != null).Count(),
                            SoldProducts = x.ProductsSold.Select(p => new ProductsExportModel
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                        }
                    }).ToArray()
            };

            return XmlConverter.Serialize(users, "Users");
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            //Get all categories. For each category select its name, the number of products, the average price of those products and the total revenue (total price sum) of those products (regardless if they have a buyer or not). Order them by the number of products (descending) then by total revenue.

            var categories = context.Categories
                .Select(x => new CategoriesExportModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            return XmlConverter.Serialize(categories, "Categories");
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold item. Order them by last name, then by first name. Select the person's first and last name. For each of the sold products, select the product's name and price. Take top 5 records.

            var users = context.Users.Where(x => x.ProductsSold.Count > 0)
                .Select(x => new UsersExportModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Products = new SoldProductsExportModel
                    {
                        Count = x.ProductsSold.Count,
                        SoldProducts = x.ProductsSold.Select(p => new ProductsExportModel
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToArray()
                    }
                })
                .OrderBy(x=>x.LastName)
                .ThenBy(x=>x.FirstName)
                .Take(5)
                .ToArray();

            return XmlConverter.Serialize(users, "Users");

        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            //Get all products in a specified price range between 500 and 1000 (inclusive). Order them by price (from lowest to highest). Select only the product name, price and the full name of the buyer. Take top 10 records

            var products = context.Products.Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductsExportModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            return XmlConverter.Serialize(products, "Products");
        }

        private static void ImportData(ProductShopContext db)
        {
            string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            ImportUsers(db, usersXml);

            string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            ImportProducts(db, productsXml);

            string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            ImportCategories(db, categoriesXml);

            string categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            ImportCategoryProducts(db, categoryProductsXml);
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            var categoryProductDto = XmlConverter.Deserializer<CategoriesProductsImportModel>(inputXml, "CategoryProducts");
            var categoryProduct = mapper.Map<CategoryProduct[]>(categoryProductDto.Where(x => x.CategoryId != null && x.ProductId != null));
            context.CategoryProducts.AddRange(categoryProduct);
            context.SaveChanges();

            return $"Successfully imported {categoryProduct.Length}"; ;
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            var categoriesDto = XmlConverter.Deserializer<CategoriesImportModel>(inputXml, "Categories");
            var categories = mapper.Map<Category[]>(categoriesDto.Where(x=>x.Name != null));
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            var productsDto = XmlConverter.Deserializer<ProductsImportModel>(inputXml, "Products");
            var products = mapper.Map<Product[]>(productsDto);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            var usersDto = XmlConverter.Deserializer<UsersImportModel>(inputXml, "Users");
            var users = mapper.Map<User[]>(usersDto);
            context.Users.AddRange(users);

            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(config);
        }
    }
}