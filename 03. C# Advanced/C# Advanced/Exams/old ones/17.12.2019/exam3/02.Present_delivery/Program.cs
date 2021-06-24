using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Present_delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPresents = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];
            var santaRow = 0;
            var santaCol = 0;

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                    if (line[j] == 'S')
                    {
                        santaRow = i;
                        santaCol = j;
                    }
                }
            }
            var givenPresents = 0;

            var input = String.Empty;

            while (numOfPresents > 0 && ((input = Console.ReadLine()) != "Christmas morning"))
            {

                switch (input)
                {
                    case "up":
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, -1, 0, false);
                        break;
                    case "down":
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, 1, 0, false);
                        break;
                    case "right":
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, 0, 1, false);
                        break;
                    case "left":
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, 0, -1, false);
                        break;
                    default:
                        break;
                }
            }

            if (numOfPresents == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            

            var niceKidsLeft = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                    if (matrix[i, j] == 'V')
                    {
                        niceKidsLeft++;
                    }
                }
                Console.WriteLine();
            }

            string niceKidsString = niceKidsLeft == 0 ? $"Good job, Santa! {givenPresents} happy nice kid/s." : $"No presents for {niceKidsLeft} nice kid/s.";

            Console.WriteLine(niceKidsString);
        }

        private static int Move(int n, char[,] matrix, ref int santaRow, ref int santaCol, ref int numOfPresents,int givenPresents, int offsetRow, int offsetCol, bool givePresentsAnyways)
        {
            if (santaRow + offsetRow >= 0 && santaRow + offsetRow < n
                && santaCol + offsetCol >= 0 && santaCol + offsetCol < n)
            {
                var typeOfCell = matrix[santaRow + offsetRow, santaCol + offsetCol];

                if (givePresentsAnyways && typeOfCell == 'X')
                {
                    typeOfCell = 'V';
                }
                matrix[santaRow, santaCol] = '-';
                santaRow += offsetRow;
                santaCol += offsetCol;
                matrix[santaRow, santaCol] = 'S';

                switch (typeOfCell)
                {
                    case 'V':
                        givenPresents++;
                        numOfPresents--;
                        break;
                    case 'C':
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, -1, 0, true);
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, 1, 1, true);
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, 1, -1, true);
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, -1, -1, true);
                        givenPresents = Move(n, matrix, ref santaRow, ref santaCol, ref numOfPresents, givenPresents, 0, 1, false);
                        break;
                }
            }

            return givenPresents;
        }
    }
}
