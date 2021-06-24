using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> towns = new Dictionary<string, List<int>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] command = input.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string name = command[0];
                int population = int.Parse(command[1]);
                int gold = int.Parse(command[2]);

                if (!towns.ContainsKey(name))
                {
                    towns.Add(name, new List<int>{ population, gold });
                }
                else
                {
                    towns[name][0] += population;
                    towns[name][1] += gold;
                }
            }


            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Plunder")
                {
                    string town = command[1];
                    int people = int.Parse(command[2]);
                    int gold = int.Parse(command[3]);

                    Plunder(towns: towns, townToPlunder: town, peopleToKill: people, gold: gold);
                }

                else if (command[0] == "Prosper")
                {
                    string town = command[1];
                    int gold = int.Parse(command[2]);

                    Prosper(towns: towns, townToProsper: town, gold: gold);
                }
            }


            if (towns.Count > 0)
            {
                var sorted = towns.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key);
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in sorted)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");

                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        private static void Prosper(Dictionary<string, List<int>> towns, string townToProsper, int gold)
        {
            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                towns[townToProsper][1] += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {townToProsper} now has {towns[townToProsper][1]} gold.");
            }
        }

        private static void Plunder(Dictionary<string, List<int>> towns, string townToPlunder, int peopleToKill, int gold)
        {
            if (towns.ContainsKey(townToPlunder))
            {
                towns[townToPlunder][0] -= peopleToKill;
                towns[townToPlunder][1] -= gold;
                Console.WriteLine($"{townToPlunder} plundered! {gold} gold stolen, {peopleToKill} citizens killed.");

                if (towns[townToPlunder][0] <= 0 || towns[townToPlunder][1] <= 0)
                {
                    Console.WriteLine($"{townToPlunder} has been wiped off the map!");
                    towns.Remove(townToPlunder);
                }
            }
        }
    }
}
