using System;

namespace _07.NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Print(Math.Abs(n));

        }

        static void Print(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
