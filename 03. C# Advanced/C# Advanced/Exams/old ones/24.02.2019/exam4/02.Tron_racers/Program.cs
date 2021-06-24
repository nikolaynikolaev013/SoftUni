using System;
using System.Linq;

namespace _02.Tron_racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            var fRow = 0;
            var fCol = 0;
            var sRow = 0;
            var sCol = 0;


           for (int i = 0; i < size; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];

                    if (row[j] == 'f')
                    {
                        fRow = i;
                        fCol = j;
                    }
                    else if (row[j] == 's')
                    {
                        sRow = i;
                        sCol = j;
                    }
                }
            }


            string died = string.Empty;

            while (died == string.Empty)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                MovePlayer(size, matrix, ref fRow, ref fCol, ref died, 'f', 's', command[0]);
                if (died == String.Empty)
                {
                    MovePlayer(size, matrix, ref sRow, ref sCol, ref died, 's', 'f', command[1]);
                }
            }


            PrintMatrix(size, matrix);
        }

        private static void PrintMatrix(int size, char[,] matrix)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void MovePlayer(int size, char[,] matrix, ref int fRow, ref int fCol, ref string died, char thisPlayer, char opponent, string currCommand)
        {
            switch (currCommand)
            {
                case "up":
                    CalculateNewPos(size, matrix, ref fRow, ref fCol, ref died, thisPlayer, opponent, -1, 0);
                    break;
                case "down":
                    CalculateNewPos(size, matrix, ref fRow, ref fCol, ref died, thisPlayer, opponent, 1, 0);
                    break;
                case "right":
                    CalculateNewPos(size, matrix, ref fRow, ref fCol, ref died, thisPlayer, opponent, 0, 1);
                    break;
                case "left":
                    CalculateNewPos(size, matrix, ref fRow, ref fCol, ref died, thisPlayer, opponent, 0, -1);
                    break;
                default:
                    break;
            }
        }

        private static void CalculateNewPos(int size, char[,] matrix, ref int fRow, ref int fCol, ref string died, char thisPlayer, char opponent, int offsetRow, int offSetCol)
        {
            if (fRow + offsetRow >= 0 && fCol + offSetCol >= 0
                                && fRow + offsetRow < size && fCol + offSetCol < size)
            {
                fRow += offsetRow;
                fCol += offSetCol;
                MarkIt(matrix, fRow, fCol, ref died, thisPlayer, opponent);
            }
            else if (fRow + offsetRow < 0 && fCol + offSetCol >= 0
                && fRow + offsetRow < size && fCol + offSetCol < size)
            {
                fRow += offsetRow + size;
                fCol += offSetCol;
                MarkIt(matrix, fRow, fCol, ref died, thisPlayer, opponent);
            }
            else if (fRow + offsetRow >= 0 && fCol + offSetCol < 0
                && fRow + offsetRow < size && fCol + offSetCol < size)
            {
                fRow += offsetRow;
                fCol += offSetCol + size;
                MarkIt(matrix, fRow, fCol, ref died, thisPlayer, opponent);
            }
            else if (fRow + offsetRow >= 0 && fCol + offSetCol >= 0
                && fRow + offsetRow >= size && fCol + offSetCol < size)
            {
                fRow += offsetRow - size;
                fCol += offSetCol;
                MarkIt(matrix, fRow, fCol, ref died, thisPlayer, opponent);
            }
            else if (fRow + offsetRow >= 0 && fCol + offSetCol >= 0
                && fRow + offsetRow < size && fCol + offSetCol >= size)
            {
                fRow += offsetRow;
                fCol += offSetCol - size;
                MarkIt(matrix, fRow, fCol, ref died, thisPlayer, opponent);
            }
        }

        private static void MarkIt(char[,] matrix, int fRow, int fCol, ref string died, char thisPlayer, char opponent)
        {
            if (matrix[fRow, fCol] == opponent)
            {
                matrix[fRow, fCol] = 'x';
                died = thisPlayer.ToString();
            }
            else
            {
                matrix[fRow, fCol] = thisPlayer;
            }
        }
    }
}
