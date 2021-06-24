using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            FillUpEngines(engines);
            FillUpCars(engines, cars);

            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }

        private static void FillUpCars(List<Engine> engines, List<Car> cars)
        {
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var carInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                //"{model} {engine} {weight} {color}"

                var model = carInput[0];
                var engineModel = carInput[1];

                Engine engine = engines.First(x => x.Model == engineModel);

                Car car = null;

                if (carInput.Length == 4)
                {
                    var weight = double.Parse(carInput[2]);
                    var color = carInput[3];

                    car = new Car(model, engine, weight, color);
                }
                else if (carInput.Length == 3)
                {
                    var weight = 0.0d;

                    bool isWeight = double.TryParse(carInput[2], out weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carInput[2]);
                    }
                }
                else if (carInput.Length == 2)
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }
        }

        private static void FillUpEngines(List<Engine> engines)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var engineInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                //"{model} {power} {displacement} {efficiency}"
                string model = engineInput[0];
                int power = int.Parse(engineInput[1]);

                Engine engine = null;

                if (engineInput.Length == 4)
                {
                    int displacement = int.Parse(engineInput[2]);
                    string efficiency = engineInput[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (engineInput.Length == 3)
                {
                    int displacement = 0;

                    bool isDisplacement = int.TryParse(engineInput[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineInput[2]);
                    }
                }
                else if (engineInput.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }
        }
    }
}
