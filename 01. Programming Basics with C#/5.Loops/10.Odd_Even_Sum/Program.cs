using System;

namespace Odd_Even_Sum
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double sumOdd = 0;
            double sumEven = 0;
            double temp = 0;


            for (int i = 0; i <= n-1; i++)
            {
                temp = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven += temp;
                }
                else
                {
                    sumOdd += temp;
                }
            }
            if (sumOdd == sumEven)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven - sumOdd)}");
            }
        }
    }
}
