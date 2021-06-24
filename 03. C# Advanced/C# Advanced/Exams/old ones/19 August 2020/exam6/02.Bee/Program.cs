using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            var beeRow = 0;
            var beeCol = 0;

            for (int i = 0; i < size; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }

            var polinatedFlowers = 0;

            var input = String.Empty;
            var finish = false;

            while ((input = Console.ReadLine()) != "End" && !finish)
            {
                switch (input)
                {
                    case "up":
                        MoveBee(size, matrix, ref beeRow, ref beeCol, ref polinatedFlowers, ref finish, -1, 0);
                        break;
                    case "down":
                        MoveBee(size, matrix, ref beeRow, ref beeCol, ref polinatedFlowers, ref finish, 1, 0);
                        break;
                    case "right":
                        MoveBee(size, matrix, ref beeRow, ref beeCol, ref polinatedFlowers, ref finish, 0, 1);
                        break;
                    case "left":
                        MoveBee(size, matrix, ref beeRow, ref beeCol, ref polinatedFlowers, ref finish, 0, -1);
                        break;
                }
            }

            var lostBeeString = finish ? $"The bee got lost!{Environment.NewLine}" : null;
            var polinatedFlowersString = polinatedFlowers >= 5 ? $"Great job, the bee managed to pollinate {polinatedFlowers} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more";

            Console.Write(lostBeeString);
            Console.WriteLine(polinatedFlowersString);

            PrintMatrix(size, matrix);
        }

        private static void MoveBee(int size, char[,] matrix, ref int beeRow, ref int beeCol, ref int polinatedFlowers, ref bool finish, int offsetRow, int offsetCol)
        {
            matrix[beeRow, beeCol] = '.';

            if (beeRow + offsetRow >= 0 && beeCol + offsetCol >= 0
                && beeRow + offsetRow < size && beeCol + offsetCol < size)
            {
                beeRow += offsetRow;
                beeCol += offsetCol;

                if (matrix[beeRow, beeCol] == 'f')
                {
                    polinatedFlowers++;
                }
                else if (matrix[beeRow, beeCol] == 'O')
                {
                    MoveBee(size, matrix, ref beeRow, ref beeCol, ref polinatedFlowers, ref finish, offsetRow, offsetCol);
                }
                else
                {
                    matrix[beeRow, beeCol] = 'B';
                }
            }
            else
            {
                finish = true;
            }
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
    }
}
