using System;

namespace _Simple_Operations_And_Calculations__Uprajnenie
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());

            Console.WriteLine($"{input * 1.79549:F2}");
        }
    }
}
