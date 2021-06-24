using System;

namespace Excellent_Result
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
