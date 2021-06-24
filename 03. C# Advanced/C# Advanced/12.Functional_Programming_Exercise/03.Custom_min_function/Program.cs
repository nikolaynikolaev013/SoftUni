using System;
using System.Linq;

namespace _03.Custom_min_function
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> myMin = x =>
            {
                int smallest = int.MaxValue;

                foreach (var num in x)
                {
                    if (num < smallest)
                    {
                        smallest = num;
                    }
                }
                return smallest;
            };

            Console.WriteLine(myMin(numbers));
        }
    }
}
