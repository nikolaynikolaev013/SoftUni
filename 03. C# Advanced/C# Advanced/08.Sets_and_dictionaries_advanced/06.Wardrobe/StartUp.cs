using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> ", ","}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!wardrobe.ContainsKey(input[0]))
                {
                    wardrobe.Add(input[0], new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    if (wardrobe[input[0]].ContainsKey(input[j]))
                    {
                        wardrobe[input[0]][input[j]]++;
                    }
                    else
                    {
                        wardrobe[input[0]].Add(input[j], 1);
                    }
                }
            }

            string[] searchFor = Console.ReadLine().Split(" ", StringSplitOptions.None);
            string colorForSearch = searchFor[0];
            string clothForSearch = searchFor[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var cloth in item.Value)
                {
                    if (item.Key == colorForSearch && cloth.Key == clothForSearch)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {

                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
