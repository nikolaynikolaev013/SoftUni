using System;

namespace Metric_Converter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputType = Console.ReadLine();
            string outputType = Console.ReadLine();

            double temp = number;

            if (inputType == "mm")
            {
                temp = number / 1000;
            }
            else if (inputType == "cm")
            {
                temp = number / 100;
            }


            if (outputType == "mm")
            {
                temp = temp * 1000;
            }
            else if (outputType == "cm")
            {
                temp = temp * 100;
            }

            Console.WriteLine($"{temp:F3}");
        }
    }
}
