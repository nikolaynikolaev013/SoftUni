using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            double average = numbers.Average();

            List<int> topNums = new List<int>();
            int counter = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    topNums.Add(numbers[i]);
                }
            }

            topNums.Sort();
            topNums.Reverse();

            if (topNums.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            int length = 5;

            if (topNums.Count < 5)
            {
                length = topNums.Count;
            }
            Console.WriteLine(String.Join(" ", topNums.GetRange(0, length)));
        }
    }
}
