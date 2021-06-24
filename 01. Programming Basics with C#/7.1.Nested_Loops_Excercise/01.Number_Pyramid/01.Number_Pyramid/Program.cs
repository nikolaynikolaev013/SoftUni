using System;

namespace Number_Pyramid
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 1;

            for (int i = 1; i <= n;)
            {
                for (int j = 0; j < counter; j++)
                {
                    Console.Write($"{i} ");
                    i++;
                    if (i > n)
                    {
                        break;
                    }
                }
                counter++;
                Console.WriteLine();
            }
        }
    }
}
