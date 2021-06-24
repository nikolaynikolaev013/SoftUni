using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "swap":
                        Swap(numbers, index1: int.Parse(commands[1]), index2: int.Parse(commands[2]));
                        break;
                    case "multiply":
                        Multiply(numbers, index1: int.Parse(commands[1]), index2: int.Parse(commands[2]));
                        break;
                    case "decrease":
                        Decrease(numbers);
                        break;
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }


        private static void Decrease(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] -= 1;
            }
        }

        private static void Multiply(List<int> numbers, int index1, int index2)
        {
            int temp = numbers[index1] * numbers[index2];

            numbers[index1] = temp;
        }

        private static void Swap(List<int> numbers, int index1, int index2)
        {
            int temp = numbers[index1];

            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }
    }
}
