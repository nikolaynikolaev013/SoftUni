using System;
using System.Linq;

namespace _06.Reverse_and_exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            var devisibleBy = int.Parse(Console.ReadLine());

            numbers = numbers.Where(x => x % devisibleBy != 0).Reverse().ToList();

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
