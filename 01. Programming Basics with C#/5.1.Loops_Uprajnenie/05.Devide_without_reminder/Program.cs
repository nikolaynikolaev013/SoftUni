using System;

namespace Devide_without_reminder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double temp = 0;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i <= n-1; i++)
            {
                temp = double.Parse(Console.ReadLine());

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

            temp = p1;
            p1 = temp / n * 100;

            temp = p2;
            p2 = temp / n * 100;

            temp = p3;
            p3 = temp / n * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
