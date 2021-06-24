using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            ImportData(db);

            Console.WriteLine(GetTotalSalesByCustomer(db));
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //Get all customers that have bought at least 1 car and get their names, bought cars count and total spent money on cars. Order the result list by total spent money descending then by total bought cars again in descending order. Export the list of customers to JSON in the format provided below.

            var customers = context.Customers
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Select(s => s.Car.PartCars.Select(p => p.Part).Sum(p=>p.Price)).Sum().ToString("F2")
                })
                .Where(x=>x.boughtCars > 0)
                .OrderByDescending(x=>x.spentMoney)
                .ThenByDescending(x=>x.boughtCars)
                .ToList();

            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //Get all cars along with their list of parts. For the car get only make, model and travelled distance and for the parts get only name and price (formatted to 2nd digit after the decimal point). Export the list of cars and their parts to JSON in the format provided below.

            var cars = context.Cars
                .Include(x=>x.PartCars)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },
                    parts = x.PartCars.Select(p => new {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    }).ToList()
                })
                .ToList();

            string carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return carsJson;

        }

        public static string GetLocalSuppliers(CarDealerContext context) {
            //Get all suppliers that do not import parts from abroad. Get their id, name and the number of parts they can offer to supply. Export the list of suppliers to JSON in the format provided below.

            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            var suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return suppliersJson;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            //Get all cars from make Toyota and order them by model alphabetically and by travelled distance descending. Export the list of cars to JSON in the format provided below.

            var cars = context.Cars.Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return carsJson;
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            //Get all customers ordered by their birth date ascending. If two customers are born on the same date first print those who are not young drivers (e.g. print experienced drivers first). Export the list of customers to JSON in the format provided below.

            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)

                    ,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return customersJson;
        }
        private static void ImportData(CarDealerContext db)
        {
            var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            ImportSuppliers(db, suppliersJson);

            var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            ImportParts(db, partsJson);

            var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(db, carsJson));

            var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            ImportCustomers(db, customersJson);

            var salesJson = File.ReadAllText("../../../Datasets/sales.json");
            ImportSales(db, salesJson);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var salesDto = JsonConvert.DeserializeObject<IEnumerable<SaleDto>>(inputJson);
            var sales = mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count()}.";

        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(inputJson);
            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert
                 .DeserializeObject<IEnumerable<CarDto>>(inputJson);

            var listOfCars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };
                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();

            return $"Successfully imported {listOfCars.Count()}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            var partsDto = JsonConvert.DeserializeObject<IEnumerable<PartsDto>>(inputJson);
            var suppliersIds = context.Suppliers.Select(x => x.Id).ToList();
            var parts = mapper.Map<IEnumerable<Part>>(partsDto.Where(x=>suppliersIds.Contains(x.SupplierId)));

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count()}.";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<SupplierDto>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(config);

        }
    }
}