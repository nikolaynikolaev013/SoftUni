using System;

namespace Max_Number
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            double temp = 0;


            double maxNumber = int.MinValue;

            while (counter <= n - 1)
            {
                temp = double.Parse(Console.ReadLine());

                if (temp > maxNumber)
                {
                    maxNumber = temp;
                }
                counter++;
            }

            Console.WriteLine(maxNumber);
        }
    }
}
