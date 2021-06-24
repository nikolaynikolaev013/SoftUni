using System;

namespace Equal_Sums_Even_Odd_Position
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int oddSum = 0;
            int evenSum = 0;

            int temp = 0;

            for (int i = firstNum; i <= secondNum; i++)
            {
                temp = i;
                evenSum = 0;
                oddSum = 0;

                evenSum += temp % 10;

                temp /= 10;

                oddSum += temp % 10;

                temp /= 10;

                evenSum += temp % 10;

                temp /= 10;

                oddSum += temp % 10;

                temp /= 10;

                evenSum += temp % 10;

                temp /= 10;

                oddSum += temp % 10;

                if (oddSum == evenSum)
                {
                    Console.Write(i + " ");
                }
            }

        }
    }
}
