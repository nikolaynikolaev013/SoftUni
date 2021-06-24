using System;

namespace Even_Or_Odd
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            if (Math.Abs(a) % 2 == 1)
            {
                Console.WriteLine("odd");
            }
            else
            {
                Console.WriteLine("even");
            }
        }
    }
}
