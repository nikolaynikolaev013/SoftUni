using System;

namespace _02.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int countOfCommands = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];
            var playerRow = 0;
            var playerCol = 0;


            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];

                    if (row[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }


            bool won = false;

            for (int i = 0; i < countOfCommands && !won; i++)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        MovePlayer(n, matrix, ref playerRow, ref playerCol, -1, 0, ref won);
                        break;
                    case "down":
                        MovePlayer(n, matrix, ref playerRow, ref playerCol, 1, 0, ref won);
                        break;
                    case "right":
                        MovePlayer(n, matrix, ref playerRow, ref playerCol, 0, 1, ref won);
                        break;
                    case "left":
                        MovePlayer(n, matrix, ref playerRow, ref playerCol, 0, -1, ref won);
                        break;
                    default:
                        break;
                }
            }

            var wonText = won ? "Player won!" : "Player lost!";

            Console.WriteLine(wonText);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }


        }

        private static void MovePlayer(int n, char[,] matrix, ref int playerRow, ref int playerCol, int offsetRow, int offsetCol, ref bool won)
        {
            if (matrix[playerRow, playerCol] != 'B')
            {
                matrix[playerRow, playerCol] = '-';
            }

            if (playerRow + offsetRow >= 0 && playerCol + offsetCol >= 0
                                && playerRow + offsetRow < n && playerCol + offsetCol < n
                                && matrix[playerRow + offsetRow, playerCol + offsetCol] != 'T')
            {

                playerRow += offsetRow;
                playerCol += offsetCol;
            }
            else if (playerRow + offsetRow < 0 && playerCol + offsetCol >= 0
                && playerRow + offsetRow < n && playerCol + offsetCol < n
                    && matrix[playerRow + offsetRow + n, playerCol + offsetCol] != 'T')
            {
                playerRow += offsetRow + n;
                playerCol += offsetCol;
            }
            else if (playerRow + offsetRow >= 0 && playerCol + offsetCol < 0
                && playerRow + offsetRow < n && playerCol + offsetCol < n
                    && matrix[playerRow + offsetRow, playerCol + offsetCol + n] != 'T')
            {
                playerRow += offsetRow;
                playerCol += offsetCol + n;
            }
            else if (playerRow + offsetRow >= 0 && playerCol + offsetCol >= 0
                && playerRow + offsetRow >= n && playerCol + offsetCol < n
                    && matrix[playerRow + offsetRow - n, playerCol + offsetCol] != 'T')
            {
                playerRow += offsetRow - n;
                playerCol += offsetCol;
            }
            else if (playerRow + offsetRow >= 0 && playerCol + offsetCol >= 0
                && playerRow + offsetRow < n && playerCol + offsetCol >= n
                    && matrix[playerRow + offsetRow, playerCol + offsetCol - n] != 'T')
            {
                playerRow += offsetRow;
                playerCol += offsetCol - n;
            }

            if (matrix[playerRow, playerCol] == 'B')
            {
                MovePlayer(n, matrix, ref playerRow, ref playerCol, offsetRow, offsetCol, ref won);
                return;
            }
            else if(matrix[playerRow, playerCol] == 'F')
            {
                won = true;
            }

            matrix[playerRow, playerCol] = 'f';
        }
    }
}
