using System;
using System.Linq;

namespace _06.Exercise_Multidimensional_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            int[,] matrix = new int[len, len];

            for (int rows = 0; rows < len; rows++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < len; cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
             }

            int diag1Sum = 0;
            int diag2Sum = 0;

            for (int rows = 0; rows < len; rows++)
            {
                diag1Sum += matrix[rows, rows];
                diag2Sum += matrix[rows, len - rows - 1];
            }

            Console.WriteLine(Math.Abs(diag1Sum - diag2Sum));
        }
    }
}
