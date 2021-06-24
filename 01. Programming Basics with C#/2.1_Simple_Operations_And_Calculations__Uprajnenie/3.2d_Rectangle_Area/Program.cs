using System;

namespace d_Rectangle_Area
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double length = Math.Abs(x1 - x2);
            double width = Math.Abs(y1 - y2);
            Console.WriteLine($"{length * width:F2}");
            Console.WriteLine($"{length * 2 + width * 2:F2}");
        }
    }
}
