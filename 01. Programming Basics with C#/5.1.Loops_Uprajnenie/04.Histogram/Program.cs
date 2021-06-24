using System;

namespace Histogram
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
            double p4 = 0;
            double p5 = 0;

            for (int i = 0; i <= n-1; i++)
            {
                temp = double.Parse(Console.ReadLine());

                if (temp < 200)
                {
                    p1++;
                }
                else if (temp < 400)
                {
                    p2++;
                }
                else if (temp < 600)
                {
                    p3++;
                }
                else if (temp < 800)
                {
                    p4++;
                }
                else if (temp >= 800)
                {
                    p5++;
                }
            }

            temp = p1;
            p1 = temp / n * 100;

            temp = p2;
            p2 = temp / n * 100;

            temp = p3;
            p3 = temp / n * 100;

            temp = p4;
            p4 = temp / n * 100;

            temp = p5;
            p5 = temp / n * 100;


            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
