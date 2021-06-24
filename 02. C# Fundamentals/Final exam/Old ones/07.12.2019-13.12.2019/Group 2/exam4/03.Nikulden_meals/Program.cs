using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Nikulden_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            int unlikedMeals = 0;

            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] command = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Like":
                        Like(guests: guests, command: command);
                        break;
                    case "Unlike":
                        Unlike(guests: guests, command: command, unlikedMeals: ref unlikedMeals);
                        break;
                    default:
                        break;
                }
            }

            var sorted = guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToList();

            foreach (var guest in sorted)
            {

                Console.WriteLine($"{guest.Key}: {String.Join(", ", guest.Value)}");
            }
            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }

        private static void Unlike(Dictionary<string, List<string>> guests, string[] command, ref int unlikedMeals)
        {

            string guest = command[1];
            string meal = command[2];

            if (guests.ContainsKey(guest))
            {

                if (guests[guest].Contains(meal))
                {
                    unlikedMeals++;
                    guests[guest].Remove(meal);
                    Console.WriteLine($"{guest} doesn't like the {meal}.");
                }
                else
                {
                    Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                }
            }
            else
            {
                Console.WriteLine($"{guest} is not at the party.");
            }
        }

        private static void Like(Dictionary<string, List<string>> guests, string[] command)
        {
            string guest = command[1];
            string meal = command[2];

            if (guests.ContainsKey(guest))
            {
                if (!guests[guest].Contains(meal))
                {
                    guests[guest].Add(meal);
                }
            }
            else
            {
                guests.Add(guest, new List<string> { meal });
            }
        }
    }
}
