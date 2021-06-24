using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Legendary_farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();

            legendaryItems.Add("shards", 0);
            legendaryItems.Add("fragments", 0);
            legendaryItems.Add("motes", 0);
            while (true)
            {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i+=2)
            {
                int quantity = int.Parse(input[i]);
                string item = input[i + 1].ToLower();

                if (item.ToLower() == "shards" || item.ToLower() == "fragments" || item.ToLower() == "motes")
                {
                    if (legendaryItems.ContainsKey(item))
                    {
                        legendaryItems[item.ToLower()] += quantity;
                    }


                    foreach (var leg in legendaryItems)
                    {
                        string obtainedItem = String.Empty;

                        if (leg.Value >= 250)
                        {
                            if (leg.Key.ToLower() == "shards")
                            {
                                obtainedItem = "Shadowmourne";
                            }
                            else if (leg.Key.ToLower() == "fragments")
                            {
                                obtainedItem = "Valanyr";
                            }
                            else if (leg.Key.ToLower() == "motes")
                            {
                                obtainedItem = "Dragonwrath";
                            }

                            Console.WriteLine($"{obtainedItem} obtained!");
                            legendaryItems[leg.Key] -= 250;


                            foreach (var ob in legendaryItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                            {
                                Console.WriteLine(ob.Key + ": " + ob.Value);
                            }
                            foreach (var ob in junk.OrderBy(x => x.Key))
                            {
                                Console.WriteLine(ob.Key + ": " + ob.Value);
                            }
                                return;
                        }
                    }
                }

                else
                {
                    if (junk.ContainsKey(item))
                    {
                        junk[item] += quantity;
                    }
                    else
                    {
                        junk.Add(item, quantity);
                    }
                }
            }
            }
        }
    }
}
