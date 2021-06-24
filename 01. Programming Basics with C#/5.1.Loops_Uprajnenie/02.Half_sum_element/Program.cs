using System;

namespace Half_sum_element
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int temp = 0;
            int highest = 0;

            for (int i = 0; i <= n-1; i++)
            {
                temp = int.Parse(Console.ReadLine());

                if (temp > highest)
                {
                    highest = temp;
                    sum += temp;
                }
                else
                {
                    sum += temp;
                }
            }

            if (highest == sum - highest)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum - highest}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(highest*2 - sum)}");
            }
        }
    }
}
