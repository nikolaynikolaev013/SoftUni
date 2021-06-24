using System;

namespace k1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int temp = 1;

            Console.WriteLine(temp);

            while (temp <= number)
            {
                temp = temp * 2 + 1;

                if (temp <= number)
                {
                    Console.WriteLine(temp);
                }
            }
        }
    }
}
