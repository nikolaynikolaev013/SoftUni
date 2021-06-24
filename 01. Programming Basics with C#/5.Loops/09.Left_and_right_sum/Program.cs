using System;

namespace Left_and_right_sum
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double leftSum = 0;
            double rightSum = 0;

            for (int i = 0; i < 2 * n; i++)
            {
                if (i <= n-1)
                {
                    leftSum += int.Parse(Console.ReadLine());
                }
                else
                {
                    rightSum += int.Parse(Console.ReadLine());
                }
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {rightSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}
