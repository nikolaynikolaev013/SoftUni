using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = command[0];
                var speed = int.Parse(command[1]);
                var power = int.Parse(command[2]);
                var weight = int.Parse(command[3]);
                var type = command[4];
                var pressure = new double[4];
                var age = new int[4];

                int counter = 5;
                for (int j = 0; j < 4; j++)
                {
                    pressure[j] = double.Parse(command[counter]);
                    age[j] = int.Parse(command[counter+1]);
                    counter+=2;
                }

                cars.Add(new Car(model, speed, power, weight, type, pressure, age));
            }

            string weightType = Console.ReadLine();

            var selectedCars = new List<Car>();

            if (weightType == "fragile")
            {
               selectedCars = cars.Where(x => x.Cargo.CargoType == weightType).Where(x => x.Tires.Any(x => x.Pressure < 1)).ToList();
            }
            else if (weightType == "flamable")
            {
               selectedCars = cars.Where(x => x.Cargo.CargoType == weightType).Where(x => x.Engine.EnginePower > 250).ToList();

            }

            Console.WriteLine(String.Join(Environment.NewLine, selectedCars));
        }
    }
}
