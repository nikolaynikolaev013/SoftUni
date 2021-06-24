using System;

namespace Number_Sequence
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine());

            int highestNum = 0;
            int lowestNum = 0;

            int temp = 0;

            for (int j = 0; j <= i - 1; j++)
            {

                temp = 0;

                temp = int.Parse(Console.ReadLine());

                if (temp > highestNum || j == 0)
                {
                    highestNum = temp;
                }

                if (temp < lowestNum || j == 0)
                {
                    lowestNum = temp;
                }

            }

            Console.WriteLine($"Max number: {highestNum}");
            Console.WriteLine($"Min number: {lowestNum}");
        }
    }
}
