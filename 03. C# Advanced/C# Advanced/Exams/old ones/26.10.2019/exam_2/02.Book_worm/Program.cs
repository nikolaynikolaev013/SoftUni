using System;
using System.Linq;
using System.Text;

namespace _02.Book_worm
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder initialString = new StringBuilder(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            var playerRow = 0;
            var playerCol = 0;

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {

                if (input == "up")
                {
                    MovePlayer(initialString, matrix, ref playerRow, ref playerCol, -1, 0);
                }
                else if (input == "down")
                {
                    MovePlayer(initialString, matrix, ref playerRow, ref playerCol, 1, 0);
                }
                else if (input == "left")
                {
                    MovePlayer(initialString, matrix, ref playerRow, ref playerCol, 0, -1);
                }
                else if (input == "right")
                {
                    MovePlayer(initialString, matrix, ref playerRow, ref playerCol, 0, 1);
                }
            }

            Console.WriteLine(initialString.ToString());
            PrintMatrix(n, matrix);
        }

        private static void MovePlayer(StringBuilder initialString, char[,] matrix, ref int playerRow, ref int playerCol, int offsetRow, int offsetCol)
        {
            if (playerRow + offsetRow >= 0 && playerCol + offsetCol >= 0
                && playerRow + offsetRow < matrix.GetLength(0) && playerCol + offsetCol < matrix.GetLength(1))
            {
                char currChar = matrix[playerRow + offsetRow, playerCol + offsetCol];

                if ((currChar >= 'a' && currChar <= 'z') || (currChar >= 'A' && currChar <= 'Z'))
                {
                    initialString.Append(currChar);
                }

                    matrix[playerRow + offsetRow, playerCol + offsetCol] = 'P';
                    matrix[playerRow, playerCol] = '-';

                    playerRow += offsetRow;
                    playerCol += offsetCol;
            }
            else
            {
                initialString.Remove(initialString.Length - 1, 1);
            }
        }

        private static void PrintMatrix(int n, char[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
