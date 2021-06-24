using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_and_minimum_element
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                switch (command[0])
                {
                    case 1:
                        stack.Push(command[1]);
                        break;

                    case 2:
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        break;

                    case 3:
                        MaximumNumber(stack: stack);
                        break;

                    case 4:
                        MinimumNumber(stack: stack);
                        break;
                }
            }

            Console.WriteLine(String.Join(", ", stack));
        }

        private static void MinimumNumber(Stack<int> stack)
        {
            var smallest = int.MaxValue;

            if (stack.Any())
            {
                foreach (var item in stack)
                {
                    if (item < smallest)
                    {
                        smallest = item;
                    }
                }
            }

            if (smallest != int.MaxValue)
            {
                Console.WriteLine(smallest);
            }
        }

        private static void MaximumNumber(Stack<int> stack)
        {
            var biggest = int.MinValue;

            if (stack.Any())
            {
                foreach (var item in stack)
                {
                    if (item > biggest)
                    {
                        biggest = item;
                    }
                }
            }

            if (biggest != int.MinValue)
            {
                Console.WriteLine(biggest);
            }
        }
    }
}
