using System;

namespace Sum_Number
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int j = 0; j <= i-1; j++)
            {
                sum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }

    }
}
