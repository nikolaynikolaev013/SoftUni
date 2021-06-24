using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Need_for_speed_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> cars = new Dictionary<string, List<double>>();

            for (int i = 0; i < numOfCars; i++)
            {
                string[] command = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string car = command[0];
                double mileage = int.Parse(command[1]);
                double fuel = double.Parse(command[2]);

                if (!cars.ContainsKey(car))
                {
                    cars.Add(car, new List<double>{ mileage, fuel });
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] command = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);


                if (command[0] == "Drive")
                {
                    string car = command[1];
                    double mileage = int.Parse(command[2]);
                    double fuel = double.Parse(command[3]);


                    Drive(cars, car: car, mileage: mileage, fuel: fuel);
                }

                else if (command[0] == "Refuel")
                {
                    string car = command[1];
                    double fuel = double.Parse(command[2]);

                    Refill(carsCollection: cars, car: car, fuel: fuel);
                }

                else if (command[0] == "Revert")
                {
                    string car = command[1];
                    double km = double.Parse(command[2]);

                    Revert(carsCollection: cars, car: car, km: km);
                }
            }

            PrintCars(carsCollection: cars);
        }

        private static void PrintCars(Dictionary<string, List<double>> carsCollection)
        {
            var sorted = carsCollection.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key);

            foreach (var car in sorted)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }

        private static void Revert(Dictionary<string, List<double>> carsCollection, string car, double km)
        {
            if (carsCollection.ContainsKey(car))
            {
                List<double> currCar = carsCollection[car];

                if (currCar[0] - km < 10000)
                {
                    currCar[0] = 10000;
                }
                else
                {
                    currCar[0] -= km;
                    Console.WriteLine($"{car} mileage decreased by {km} kilometers");
                }
            }
        }

        private static void Refill(Dictionary<string, List<double>> carsCollection, string car, double fuel)
        {
            if (carsCollection.ContainsKey(car))
            {
                List<double> currCar= carsCollection[car];

                if (currCar[1] + fuel > 75)
                {
                    Console.WriteLine($"{car} refueled with {75 - currCar[1]} liters");
                    currCar[1] = 75;
                }

                else
                {
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                    currCar[1] += fuel;
                }
                carsCollection[car] = currCar;

            }
        }

        private static void Drive(Dictionary<string, List<double>> cars, string car, double mileage, double fuel)
        {
            if (cars.ContainsKey(car))
            {
                List<double> currCar = cars[car];

                if (currCar[1] >= fuel)
                {
                    currCar[1] -= fuel;
                    currCar[0] += mileage;
                    Console.WriteLine($"{car} driven for {mileage} kilometers. {fuel} liters of fuel consumed.");

                    if (currCar[0] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);
                        return;
                    }

                    cars[car] = currCar;
                }
                else
                {
                    Console.WriteLine("Not enough fuel to make that ride");
                }

            }
        }
    }
}
