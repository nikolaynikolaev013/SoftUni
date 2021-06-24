using System;

namespace _07.Knight_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            char[,] board;
            FillUpMatrix(out n, out board);

            int counter = 0;
            int maxKill = 0;
            int maxKillCol = 0;
            int maxKillRow = 0;

            int killed = 0;

            //5
            //0K0K0
            //K000K
            //00K00
            //K000K
            //0K0K0


            while (true)
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            counter = AttackCheck(n, board, counter, row, col, -2, 1);
                            counter = AttackCheck(n, board, counter, row, col, -2, -1);
                            counter = AttackCheck(n, board, counter, row, col, 1, 2);
                            counter = AttackCheck(n, board, counter, row, col, -1, 2);
                            counter = AttackCheck(n, board, counter, row, col, 2, 1);
                            counter = AttackCheck(n, board, counter, row, col, 2, -1);
                            counter = AttackCheck(n, board, counter, row, col, 1, -2);
                            counter = AttackCheck(n, board, counter, row, col, -1, -2);
                            CheckMaxKill(ref counter, ref maxKill, ref maxKillCol, ref maxKillRow, row, col);
                        }

                    }
                }

                if (maxKill > 0)
                {
                    board[maxKillRow, maxKillCol] = '0';
                    maxKill = 0;
                    killed++;
                }
                else
                {
                    if (maxKill == 0)
                    {
                        break;
                    }
                }

            }

            Console.WriteLine(killed);
        }

        private static void CheckMaxKill(ref int counter, ref int maxKill, ref int maxKillCol, ref int maxKillRow, int row, int col)
        {
            if (counter > maxKill)
            {
                maxKill = counter;
                maxKillCol = col;
                maxKillRow = row;
            }
            counter = 0;
        }

        private static void FillUpMatrix(out int n, out char[,] board)
        {
            n = int.Parse(Console.ReadLine());
            board = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    board[row, col] = input[col];
                }
            }
        }

        private static int AttackCheck(int n, char[,] board, int counter, int row, int col, int moveRow, int moveCol)
        {
            if (col + moveCol < n
                && col + moveCol >= 0)
            {
                if (row + moveRow < n
                    && row + moveRow >= 0)
                {
                    if (board[row + moveRow, col + moveCol] == 'K')
                    {
                        counter++;
                    }
                }
            }


            return counter;
        }
    }
}
