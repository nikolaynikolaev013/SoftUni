using System;
using System.Linq;

namespace _02.Knights_of_honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => "Sir " + x)
                .ToArray();

            Action<string[]> printNames = x => Console.WriteLine(String.Join(Environment.NewLine, x)); ;

            printNames(names); 
        }
    }
}
