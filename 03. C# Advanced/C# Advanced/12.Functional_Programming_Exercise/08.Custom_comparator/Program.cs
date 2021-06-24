using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Custom_comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.Parse(Console.ReadLine());

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

           
        }
    }
}
