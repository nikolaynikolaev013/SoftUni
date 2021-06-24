using System;
using System.Collections.Generic;
using System.Linq;

namespace exam_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var univInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var males = new Stack<int>(univInput);

            univInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var females = new Queue<int>(univInput);
            var matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currMale = males.Peek();
                int currFemale = females.Peek();

                if (currMale <= 0)
                {
                    males.Pop();
                    continue;
                }
                else if (currMale % 25 == 0)
                {
                    males.Pop();
                    if (males.Count > 0)
                    {
                        males.Pop();
                    }
                    continue;
                }

                if (currFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                else if (currFemale % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                if (currMale == currFemale)
                {
                    matches++;
                    males.Pop();
                    females.Dequeue();
                    continue;
                }
                else
                {
                    females.Dequeue();
                    males.Pop();
                    males.Push(currMale - 2);
                    continue;
                }
            }

            string malesString = males.Count > 0 ? $"{String.Join(", ", males)}" : "none";
            string femalesString = females.Count > 0 ? $"{String.Join(", ", females)}" : "none";

            Console.WriteLine($"Matches: {matches}");
            Console.WriteLine($"Males left: {malesString}");
            Console.WriteLine($"Females left: {femalesString}");
        }
    }
}
