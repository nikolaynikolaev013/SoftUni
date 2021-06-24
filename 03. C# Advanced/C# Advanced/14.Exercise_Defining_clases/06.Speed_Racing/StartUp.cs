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
                var carInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car currCar = new Car(carInput[0], double.Parse(carInput[1]), double.Parse(carInput[2]));

                cars.Add(currCar);
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string carModel = command[1];
                double km = double.Parse(command[2]);

                if (cars.Any(x => x.Model == carModel))
                {
                    Car car = (Car)cars.Where(x => x.Model == carModel).ToList()[0];
                    car.DriveCar(km);
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }
    }
}
