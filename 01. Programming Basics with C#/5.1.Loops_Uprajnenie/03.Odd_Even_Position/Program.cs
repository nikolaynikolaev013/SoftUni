using System;

namespace Odd_Even_Position
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double temp = 0;

            double oddSum = 0;
            double oddMin = 0;
            double oddMax = 0;
            double evenSum = 0;
            double evenMin = 0;
            double evenMax = 0;

            for (int i = 1; i <= n; i++)
            {
                temp = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += temp;

                    if (temp < evenMin || i == 2)
                    {
                        evenMin = temp;
                    }
                    if (temp > evenMax || i == 2)
                    {
                        evenMax = temp;
                    }
                }
                else
                {
                    oddSum += temp;

                    if (temp < oddMin || i == 1)
                    {
                        oddMin = temp;
                    }

                    if (temp > oddMax || i == 1)
                    {
                        oddMax = temp;
                    }
                }
            }


            Console.WriteLine($"OddSum={oddSum:F2},");
            CheckValue("OddMin", oddMin);
            CheckValue("OddMax", oddMax);
            Console.WriteLine($"EvenSum={evenSum:F2},");
            CheckValue("EvenMin", evenMin);
            CheckValue("EvenMax", evenMax);
        }


        public static void CheckValue (string text, double value)
        {
            if (text != "EvenMax")
            {
                if (value != 0)
                {
                    Console.WriteLine($"{text}={value:F2},");
                }
                else
                {
                    Console.WriteLine($"{text}=No,");
                }
            }
            else
            {
                if (value != 0)
                {
                    Console.WriteLine($"{text}={value:F2}");
                }
                else
                {
                    Console.WriteLine($"{text}=No");
                }
            }
        }
    }
}
