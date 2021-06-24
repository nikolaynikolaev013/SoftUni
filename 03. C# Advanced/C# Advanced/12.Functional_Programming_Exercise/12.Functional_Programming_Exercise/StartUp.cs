using System;
using System.Linq;

namespace _12.Functional_Programming_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> pr = m => Console.WriteLine(String.Join(Environment.NewLine, m)); ;

            pr(input);

        }
    }
}
