using System;
using System.Linq;

namespace _03.Maximal_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nAndM = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = nAndM[0];
            int m = nAndM[1];

            var matrix = new int[n, m];

            for (int rows = 0; rows < n; rows++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < m; cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            int maxSum = int.MinValue;
            int startIndexRow = 0;
            int startIndexCol = 0;

            for (int rows = 0; rows < n - 2; rows++)
            {
                for (int cols = 0; cols < m - 2; cols++)
                {
                    int currSum = 0;

                    for (int i = 0; i <= 2; i++)
                    {
                        for (int j = 0; j <= 2; j++)
                        {
                            currSum += matrix[rows + i, cols + j];
                        }
                    }
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        startIndexRow = rows;
                        startIndexCol = cols;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int rows = startIndexRow; rows <= startIndexRow + 2; rows++)
            {
                for (int cols = startIndexCol; cols <= startIndexCol + 2; cols++)
                {
                    Console.Write($"{matrix[rows, cols]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
