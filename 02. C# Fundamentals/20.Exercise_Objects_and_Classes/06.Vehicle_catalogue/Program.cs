using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Vehicle_catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                vehicles.Add(new Vehicle(command[0], command[1], command[2], int.Parse(command[3])));
            }


            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                Console.WriteLine(vehicles.Find(x=>x.Model == input).ToString());
            }

            List<Vehicle> trucks = new List<Vehicle>();
                trucks = vehicles.FindAll(x => x.Type == "truck").ToList();
            List<Vehicle> cars = new List<Vehicle>();
                cars = vehicles.FindAll(x => x.Type == "car").ToList();

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {cars.Average(x => x.Horsepower):F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucks.Average(x => x.Horsepower):F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; } = 0;

        public Vehicle(string type, string model, string color, int horsepower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            if (this.Type == "car")
            {
                str.AppendLine($"Type: Car");
            }
            else
            {
                str.AppendLine($"Type: Truck");
            }
            str.AppendLine($"Model: {this.Model}");
            str.AppendLine($"Color: {this.Color}");
            str.AppendLine($"Horsepower: {this.Horsepower}");

            return str.ToString().Trim();
            
        }
    }
}
