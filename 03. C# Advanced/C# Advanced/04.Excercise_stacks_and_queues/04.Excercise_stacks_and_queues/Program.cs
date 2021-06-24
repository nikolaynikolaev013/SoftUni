using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.Exercise_stacks_and_queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = nsx[0];
            int s = nsx[1];
            int x = nsx[2];


            if (s > n)
            {
                return;
            }

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(input) { };

            for (int i = 0; i < s; i++)
            {
                if (stack.Count() > 0)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {

                if (stack.Count() <= 0)
                {
                    Console.WriteLine("0");
                    return;
                }

                Console.WriteLine(stack.Min());
            }

        }
    }
}

