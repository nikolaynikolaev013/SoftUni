using System;

namespace Passed_or_failed
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 3.0)
            {
                Console.WriteLine("Passed!");
            }
            else if (grade < 3)
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}
