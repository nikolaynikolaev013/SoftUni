using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var N = command[0];
            var S = command[1];
            var X = command[2];

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            foreach (var val in input)
            {
                queue.Enqueue(val);
            }

            for (int i = 0; i < S && queue.Any(); i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                var smallest = int.MaxValue;
                if (queue.Any())
                {
                    foreach (var item in queue)
                    {
                        if (item < smallest)
                        {
                            smallest = item;
                        }
                    }
                    Console.WriteLine(smallest);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
