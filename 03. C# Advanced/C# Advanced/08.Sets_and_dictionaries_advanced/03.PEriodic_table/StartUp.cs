using System;
using System.Collections.Generic;

namespace _03.PEriodic_table
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in input)
                {
                    set.Add(item);
                }
            }

            foreach (var item in set)
            {
                Console.Write(item + " ");
            }
        }
    }
}
