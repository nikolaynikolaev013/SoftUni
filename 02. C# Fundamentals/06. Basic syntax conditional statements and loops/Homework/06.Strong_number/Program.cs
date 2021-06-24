using System;

namespace Stong_Number
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int temp = 0;
            int total = 0;
            int grandTotal = 0;

            for (int i = 0; i <= number.Length - 1; i++)
            {
                temp = int.Parse(number[i].ToString());

                total = 1;
                for (int j = 1; j <= temp; j++)
                {
                    total *= j;
                }

                grandTotal += total;
            }

            if (grandTotal == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}

