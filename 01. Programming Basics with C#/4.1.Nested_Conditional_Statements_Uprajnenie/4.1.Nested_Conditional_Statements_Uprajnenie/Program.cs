using System;

namespace Nested_Conditional_Statements_Uprajnenie
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool isBottom = x >= x1 && x <= x2 && y == y2;
            bool isTop = x >= x1 && x <= x2 && y == y1;
            bool isLeft = y >= y1 && y <= y2 && x == x1;
            bool isRight = y >= y1 && y <= y2 && x == x2;

            if (isBottom || isTop || isLeft || isRight)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
