using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalQuantity = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            var queue = new Queue<int>();

            foreach (var item in input)
            {
                queue.Enqueue(item);
            }

            if (queue.Any())
            {
                int biggestOne = 0;

                for (int i = 0; i < queue.Count; i++)
                {
                    if (queue.Peek() > biggestOne)
                    {
                        biggestOne = queue.Peek();

                    }
                    if (queue.Peek() <= totalQuantity)
                    {
                        totalQuantity -= queue.Peek();
                        queue.Dequeue();
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
               
                Console.WriteLine(biggestOne);

                if (!queue.Any())
                {
                    Console.WriteLine("Orders complete");
                }
                else
                {
                    Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
                }
            }

        }
    }
}
