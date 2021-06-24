using System;
using System.Linq;

namespace _06.Jagged_array_manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal[][] arr = new decimal[n][];

            for (int row = 0; row < n; row++)
            {
                decimal[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();

                arr[row] = numbers;
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (arr[row].Length == arr[row+1].Length)
                {
                    for (int col = 0; col < arr[row].Length; col++)
                    {
                        arr[row][col] *= 2;
                    }
                    for (int col = 0; col < arr[row+1].Length; col++)
                    {
                        arr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < arr[row].Length; col++)
                    {
                        arr[row][col] /= 2;
                    }
                    for (int col = 0; col < arr[row + 1].Length; col++)
                    {
                        arr[row + 1][col] /= 2;
                    }
                }
            }


            string input = String.Empty;

            while((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "Add")
                {
                    Add(arr, command);
                }
                else if (command[0] == "Subtract")
                {
                    Substract(arr, command);
                }
            }

            for (int row = 0; row < arr.Length; row++)
            {
                Console.WriteLine(String.Join(" ", arr[row]));
            }

        }

        private static void Add(decimal[][] arr, string[] command)
        {
            if (command.Length == 4)
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < arr.Length
                    && row >= 0
                    && col < arr[row].Length
                    && col >= 0)
                {
                    arr[row][col] += value;
                }
            }
        }

        private static void Substract(decimal[][] arr, string[] command)
        {
            if (command.Length == 4)
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < arr.Length
                    && row >= 0
                    && col < arr[row].Length
                    && col >= 0)
                {
                    arr[row][col] -= value;
                }
            }
        }
    }
}
