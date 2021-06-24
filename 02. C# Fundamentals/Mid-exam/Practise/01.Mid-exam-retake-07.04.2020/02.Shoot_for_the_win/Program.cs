using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Shoot_for_the_win
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = String.Empty;
            int targetCounter = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                int index = int.Parse(input);

                if (index < targets.Count && index >= 0 && targets[index] > -1)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (i != index)
                        {
                            if (targets[i] > targets[index])
                            {
                                targets[i] -= targets[index];
                            }
                            else if (targets[i] <= targets[index] && targets[i] != -1)
                            {
                                targets[i] += targets[index];
                            }
                        }
                    }

                    targets[index] = -1;
                    targetCounter++;
                }
            }
            Console.WriteLine($"Shot targets: {targetCounter} -> {String.Join(" ", targets)}");


        }
    }
}
