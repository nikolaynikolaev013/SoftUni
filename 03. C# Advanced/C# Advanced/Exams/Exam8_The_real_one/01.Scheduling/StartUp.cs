using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var univInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var tasks = new Stack<int>(univInput);

            univInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var threads = new Queue<int>(univInput);

            var taskToKill = int.Parse(Console.ReadLine());

            var stopIt = false;

            while (!stopIt)
            {
                var currTask = tasks.Peek();
                var currThread = threads.Peek();


                if (currTask == taskToKill)
                {
                    stopIt = true;
                    break;
                }

                if (currThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }

            }


            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            Console.WriteLine($"{String.Join(" ", threads)}");
        }
    }
}
