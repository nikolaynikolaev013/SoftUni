using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] cells = new int[n, n];

            FillUpArray(n, cells);

            var bombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var bomb in bombs)
            {
                var currBomb = bomb.Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var bombRow = currBomb[0];
                var bombCol = currBomb[1];
                var bombValue = cells[bombRow, bombCol];

                if (bombValue>0)
                {
                    ReduceNeighbour(n, cells, bombRow, bombCol, bombValue, 0, 1);
                    ReduceNeighbour(n, cells, bombRow, bombCol, bombValue, 1, 1);
                    ReduceNeighbour(n, cells, bombRow, bombCol, bombValue, 1, 0); 
                    ReduceNeighbour(n, cells, bombRow, bombCol, bombValue, 1, -1);
                    ReduceNeighbour(n, cells, bombRow, bombCol, bombValue, 0, -1);
                    ReduceNeighbour(n, cells, bombRow, bombCol, bombValue, -1, -1);
                    ReduceNeighbour(n, cells, bombRow, bombCol, bombValue, -1, 0);
                    ReduceNeighbour(n, cells, bombRow, bombCol, bombValue, -1, 1); 
                    cells[bombRow, bombCol] = 0;
                }
            }

            var aliveCells = 0;
            var aliveCellsSum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cells[i,j] > 0)
                    {
                        aliveCells++;
                        aliveCellsSum += cells[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintArray(n, cells);
        }

        private static void ReduceNeighbour(int n, int[,] cells, int bombRow, int bombCol, int bombValue, int rowOffset, int colOffset)
        {
            if (bombRow + rowOffset < n && bombRow + rowOffset >= 0)
            {
                if (bombCol + colOffset < n && bombCol + colOffset >= 0)
                {
                    if (cells[bombRow + rowOffset, bombCol + colOffset] > 0)
                    {
                        cells[bombRow + rowOffset, bombCol + colOffset] -= bombValue;
                    }
                }
            }
        }

        private static void PrintArray(int n, int[,] cells)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{cells[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void FillUpArray(int n, int[,] cells)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
                {
                    cells[i, j] = input[j];
                }
            }
        }
    }
}
