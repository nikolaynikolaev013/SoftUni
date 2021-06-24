using System;
using System.Collections.Generic;
using System.Linq;

namespace exam4
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var halls = new Queue<string>();

            var reservations = new Queue<int>();

            while (input.Count > 0)
            {
                var curr = input.Last();
                input.RemoveAt(input.Count - 1);
                var num = 0;

                if (int.TryParse(curr, out num))
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (reservations.Sum() + num > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {String.Join(", ", reservations)}");

                        reservations = new Queue<int>();
                    }
                    else if (reservations.Sum() + num == maxCapacity)
                    {
                        reservations.Enqueue(num);

                        Console.WriteLine($"{halls.Dequeue()} -> {String.Join(", ", reservations)}");

                        reservations = new Queue<int>();
                        continue;
                    }

                    if (halls.Count > 0)
                    {
                        reservations.Enqueue(num);
                    }

                }
                else
                {
                    halls.Enqueue(curr);
                }
            }
        }
    }
}
