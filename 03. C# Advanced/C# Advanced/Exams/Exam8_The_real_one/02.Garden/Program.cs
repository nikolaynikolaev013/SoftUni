using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var univInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[univInput[0], univInput[1]];

            var flowers = new Dictionary<int, List<int>>();

            var input = String.Empty;
            var counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }

            while ((input = Console.ReadLine())!= "Bloom Bloom Plow")
            {
                var coordinates = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var row = coordinates[0];
                var col = coordinates[1];

                if (row < 0 || row > matrix.GetLength(0)
                    || col < 0 || col > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                flowers.Add(counter, new List<int>() { row, col });
                counter++;
            }

            foreach (var flower in flowers)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[flower.Value[0], i]++;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, flower.Value[1]]++;
                }

                matrix[flower.Value[0], flower.Value[1]]--;
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
