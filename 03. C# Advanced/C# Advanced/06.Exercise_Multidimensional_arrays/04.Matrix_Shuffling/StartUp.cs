using System;
using System.Linq;

namespace _04.Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = coordinates[0];
            int cols = coordinates[1];

            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] command = Console.ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = command[col];
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "swap" && command.Length == 5)
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);

                    if (row1 < rows
                        && row1 >= 0
                        && col1 < cols
                        && col1 >= 0
                        && row2 < rows
                        && row2 >= 0
                        && col2 < cols
                        && col2 >= 0
                        )
                    {
                        string text1 = matrix[row1, col1];
                        string text2 = matrix[row2, col2];

                        matrix[row1, col1] = text2;
                        matrix[row2, col2] = text1;
                        PrintMatrix(rows, cols, matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(int rows, int cols, string[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
