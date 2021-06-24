using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sets_of_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();


            int n = input[0];
            int m = input[1];

            for (int i = 0; i < n; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var item in set1)
            {
                if (set2.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
