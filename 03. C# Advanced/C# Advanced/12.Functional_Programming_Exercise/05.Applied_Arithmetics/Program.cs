using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = numbers.Select(x => x += 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x *= 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => x -= 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
