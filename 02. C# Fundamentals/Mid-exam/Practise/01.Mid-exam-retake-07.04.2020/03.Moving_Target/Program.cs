using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End") 
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Shoot":
                        Shoot(targets, index: int.Parse(command[1]), power: int.Parse(command[2]));
                        break;
                    case "Add":
                        Add(targets, index: int.Parse(command[1]), value: int.Parse(command[2]));
                        break;
                    case "Strike":
                        Strike(targets, index: int.Parse(command[1]), radius: int.Parse(command[2]));
                        break;
                }
            }

            Console.WriteLine(String.Join("|", targets));
        }

        private static void Strike(List<int> targets, int index, int radius)
        {
            if (index >= 0 && index < targets.Count)
            {
                if (index - radius >= 0 && index + radius < targets.Count)
                {
                    targets.RemoveRange(index - radius, index + radius + index - radius - 1);
                }
                else
                {
                    Console.WriteLine("Stike missed!");
                }
            }
        }

        private static void Add(List<int> targets, int index, int value)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        private static void Shoot(List<int> targets, int index, int power)
        {
            if (index >= 0 && index < targets.Count)
            {
                if (targets[index] > 0)
                {
                    targets[index] -= power;
                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }
            }
        }
    }
}
