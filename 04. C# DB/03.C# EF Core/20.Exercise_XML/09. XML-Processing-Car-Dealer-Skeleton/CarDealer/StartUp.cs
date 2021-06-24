using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;
using CarDealer.XmlHelper;

namespace CarDealer
{
    public class StartUp
    {
        private static Mapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            ImportData(db);
            System.Console.WriteLine(GetTotalSalesByCustomer(db));
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //Get all sales with information about the car, customer and price of the sale with and without discount.

            var sales = context.Sales
                .Select(x => new SaleOutputModel
                {
                    Car = new SaleCarOutputModel
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = decimal.Parse(x.Car.PartCars.Sum(p => p.Part.Price).ToString()),

                    PriceWithDiscount = decimal.Parse((x.Car.PartCars.Sum(p => p.Part.Price) * (1 - (x.Discount / 100))).ToString("F2"))

                })
                .ToArray();

            return XmlConverter.Serialize(sales, "sales");
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context) {
            //Get all customers that have bought at least 1 car and get their names, bought cars count and total spent money on cars. Order the result list by total spent money descending.

            var customers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .ToArray()
                .Select(x => new CustomerOutputModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Select(s => s.Car)
                                .SelectMany(s => s.PartCars)
                                .Sum(s => s.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney);


            return XmlConverter.Serialize(customers, "customers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //Get all cars along with their list of parts. For the car get only make, model and travelled distance and for the parts get only name and price and sort all parts by price (descending). Sort all cars by travelled distance (descending) then by model (ascending). Select top 5 records.

            var cars = context.Cars
                .Select(x => new CarWithPartsOutputModel {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new PartOutputModel {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(x=>x.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            return XmlConverter.Serialize(cars, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            //Get all suppliers that do not import parts from abroad.Get their id, name and the number of parts they can offer to supply.

            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new SuppliersAndPartsOutputModel {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();


            return XmlConverter.Serialize(suppliers, "suppliers");
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            //Get all cars from make BMW and order them by model alphabetically and by travelled distance descending
            var cars = context.Cars.Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new BMWCarsOutputModel {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var result = XmlConverter.Serialize(cars, "cars");
            return result;

        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            //Get all cars with distance more than 2,000,000. Order them by make, then by model alphabetically. Take top 10 records.
            var cars = context.Cars.Where(x => x.TravelledDistance > 2_000_000)
                .Select(x=>new CarOutputModel{
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            //var serializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("cars"));
            //var writer = new StringWriter();
            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");
            //serializer.Serialize(writer, cars, ns);

            var result = XmlConverter.Serialize(cars, "cars");

            return result;
        }

        private static void ImportData(CarDealerContext db)
        {
            var supplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            ImportSuppliers(db, supplierXml);

            var partXml = File.ReadAllText("../../../Datasets/parts.xml");
            ImportParts(db, partXml);

            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            ImportCars(db, carsXml);

            var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            ImportCustomers(db, customersXml);

            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            ImportSales(db, salesXml);
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            var cars = context.Cars.Select(x => x.Id);

            var serializer = new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute("Sales"));
            var reader = new StringReader(inputXml);
            var salesDto = (SaleInputModel[])serializer.Deserialize(reader);
            var sales = mapper.Map<Sale[]>(salesDto.Where(x => cars.Contains(x.CarId)));

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}"; ;
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));
            var stringReader = new StringReader(inputXml);
            var customersDto = (CustomerInputModel[])serializer.Deserialize(stringReader);
            var customers = mapper.Map<Customer[]>(customersDto);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Length}"; ;
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var xmlSerializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            var strReader = new StringReader(inputXml);
            var carsDto = (CarInputModel[]) xmlSerializer.Deserialize(strReader);
            var cars = new List<Car>();

            var validParts = context.Parts.Select(x => x.Id).ToList();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };


                var parts = validParts.Intersect(car.Parts.Select(x=>x.Id).Distinct());

                foreach (var part in parts)
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = part
                    });
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var xmlSerializer = new XmlSerializer(typeof(PartsInputModel[]), new XmlRootAttribute("Parts"));
            var stringReader = new StringReader(inputXml);
            var partsDto = (PartsInputModel[])xmlSerializer.Deserialize(stringReader);
            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();
            var parts = mapper.Map<Part[]>(partsDto.Where(x=>supplierIds.Contains(x.SupplierId)));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var strReader = new StringReader(inputXml);
            var suppliersDto = (SupplierInputModel[]) xmlSerializer.Deserialize(strReader);
            var suppliers = mapper.Map<Supplier[]>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(x => {
                x.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(config);
        }
    }
}