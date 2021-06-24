using System;
using System.Linq;

namespace _02._2x2_Squares_in_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rowsLen = rowsAndCols[0];
            int colsLen = rowsAndCols[1];

            var matrix = new string[rowsLen, colsLen];

            for (int rows = 0; rows < rowsLen; rows++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int cols = 0; cols < colsLen; cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            int counter = 0;

            for (int rows = 0; rows < rowsLen - 1; rows++)
            {
                for (int cols = 0; cols < colsLen - 1; cols++)
                {
                    string currChar = matrix[rows, cols];

                    if (currChar == matrix[rows, cols+1]
                        && currChar == matrix[rows+1, cols]
                        && currChar == matrix[rows+1, cols+1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
