using System;

namespace Radians_To_Degrees
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());

            Console.WriteLine($"{Math.Round(rad*180/Math.PI, 0)}");
        }
    }
}
