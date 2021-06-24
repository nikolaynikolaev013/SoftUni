using System;

namespace Min_Number
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            double temp = 0;
            double minNumber = int.MaxValue;

            while (counter <= n-1)
            {
                temp = double.Parse(Console.ReadLine());

                if (temp < minNumber)
                {
                    minNumber = temp;
                }
                counter++;
            }


            Console.WriteLine(minNumber);
        }
    }
}
