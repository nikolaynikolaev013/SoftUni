using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Find_even_or_odd
{
    class Program
    {
        static void Main(string[] args)
        {
            var ranges = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var start = ranges[0];
            var end = ranges[1];

            var evenOrOdd = Console.ReadLine();

            Func<int, int,string, List<int>> findEverOrOdd = (s, e, c) =>
            {
                var newList = new List<int>();

                if (c == "even")
                {
                    for (int i = s; i <= e; i++)
                    {
                        if (i % 2 == 0)
                        {
                            newList.Add(i);
                        }
                    }
                }
                else
                {
                    for (int i = s; i <= e; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newList.Add(i);
                        }
                    }
                }

                return newList;
            };


            Console.WriteLine(String.Join(" ", findEverOrOdd(start, end, evenOrOdd)));
        }
    }
}
