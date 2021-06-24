using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Hero_recruiment
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();


            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Enroll":
                        Enroll(heroes: heroes, heroName: command[1]);
                        break;
                    case "Learn":
                        Learn(heroes: heroes, command: command);
                        break;
                    case "Unlearn":
                        Unlearn(heroes: heroes, command: command);
                        break;
                    default:
                        break;
                }
            }

            var sorted = heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            Console.WriteLine("Heroes:");
            foreach (var hero in sorted)
            {
                Console.WriteLine($"== {hero.Key}: {String.Join(", ", hero.Value)}");
            }
        }

        private static void Unlearn(Dictionary<string, List<string>> heroes, string[] command)
        {
            string heroName = command[1];
            string spellName = command[2];

            if (heroes.ContainsKey(heroName))
            {
                if (heroes[heroName].Contains(spellName))
                {
                    heroes[heroName].Remove(spellName);
                }
                else
                {
                    Console.WriteLine($"{heroName} doesn't know {spellName}.");
                }
            }
            else
            {
                Console.WriteLine($"{heroName} doesn't exist.");
            }
        }

        private static void Learn(Dictionary<string, List<string>> heroes, string[] command)
        {
            string heroName = command[1];
            string spellName = command[2];

            if (heroes.ContainsKey(heroName))
            {
                if (!heroes[heroName].Contains(spellName))
                {
                    heroes[heroName].Add(spellName);
                }
                else
                {
                    Console.WriteLine($"{heroName} has already learnt {spellName}.");
                }
            }
            else
            {
                Console.WriteLine($"{heroName} doesn't exist.");
            }
        }

        public static void Enroll(Dictionary<string, List<string>> heroes, string heroName)
        {
            if (heroes.ContainsKey(heroName))
            {
                Console.WriteLine($"{heroName} is already enrolled.");
            }
            else
            {
                heroes.Add(heroName, new List<string> { });
            }
        }

    }
}
