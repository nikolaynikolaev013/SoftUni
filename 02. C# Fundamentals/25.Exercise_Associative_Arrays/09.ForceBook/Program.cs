using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] command = input.Split(" | ");
                    string forceSide = command[0];
                    string forceUser = command[1];


                    if (!sides.ContainsKey(forceSide))
                    {
                        sides.Add(forceSide, new List<string> {});
                    }

                    if (!sides[forceSide].Contains(forceUser) && !sides.Values.Any(x=>x.Contains(forceUser)))
                    {
                        sides[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    string[] command = input.Split(" -> ");
                    string forceUser = command[0];
                    string forceSide = command[1];

                    if (sides.ContainsKey(forceSide))
                    {
                        if (!sides.ContainsKey(forceUser))
                        {
                            sides[forceSide].Add(forceUser);
                        }

                        foreach (var item in sides)
                        {
                            if (item.Value.Contains(forceUser))
                            {
                                item.Value.Remove(forceUser);
                                break;
                            }
                        }

                        sides[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
            }

            foreach (var item in sides.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    foreach (var user in item.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
