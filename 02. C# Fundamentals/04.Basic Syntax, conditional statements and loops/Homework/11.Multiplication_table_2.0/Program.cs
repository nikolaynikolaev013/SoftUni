using System;

namespace Multiplication_table_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplicator = int.Parse(Console.ReadLine());


            do
            {
                Console.WriteLine($"{n} X {multiplicator} = {n * multiplicator}");
                multiplicator++;
            } while (multiplicator <= 10);
        }
    }
}
