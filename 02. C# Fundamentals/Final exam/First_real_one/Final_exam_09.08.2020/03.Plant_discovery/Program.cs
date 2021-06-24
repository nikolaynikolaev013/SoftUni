using System;
using System.Collections.Generic;

namespace _03.Plant_discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<int, List<double>>> plants = new Dictionary<string, Dictionary<int, List<double>>>();


            for (int i = 0; i < number; i++)
            {
                string[] plant = Console.ReadLine().Split("<=>", StringSplitOptions.RemoveEmptyEntries);

                if (!plants.ContainsKey(plant[0]))
                {
                    plants.Add(plant[0], new List<double>(double.Parse(plant[1], 0)));
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Rate:":
                        Rate(plants: plants, command: command);
                        break;
                    case "Update:":
                        Update(plants: plants, command: command);
                        break;
                    case "Reset:":
                        Reset(plants: plants, command: command);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {}");
            }

        }

        private static void Reset(Dictionary<string, List<double>> plants, string[] command)
        {
            string plant = command[1];

            if (plants.ContainsKey(plant))
            {
                plants[plant][1] = 0;
            }
        }

        private static void Update(Dictionary<string, List<double>> plants, string[] command)
        {
            string plant = command[1];
            double newRarity = double.Parse(command[3]);

            if (plants.ContainsKey(plant))
            {
                plants[plant][0] = newRarity;
            }
        }

        private static void Rate(Dictionary<string, List<double>> plants, string[] command)
        {
            string plant = command[1];
            double rating = double.Parse(command[3]);

            if (plants.ContainsKey(plant))
            {
                plants[plant][1] = rating;
            }
        }
    }
}
