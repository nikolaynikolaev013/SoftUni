using System;

namespace Division_Without_Remainder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int temp = 0;

            for (int i = 0; i < n; i++)
            {
                temp = int.Parse(Console.ReadLine());

                if (temp % 2 == 0)
                {
                    p1++;
                }

                if (temp % 3 == 0)
                {
                    p2++;
                }

                if (temp % 4 == 0)
                {
                    p3++;
                }
            }

            Console.WriteLine($"{(100.0 / n) * p1:F2}%");
            Console.WriteLine($"{(100.0 / n) * p2:F2}%");
            Console.WriteLine($"{(100.0 / n) * p3:F2}%");
        }
    }
}

