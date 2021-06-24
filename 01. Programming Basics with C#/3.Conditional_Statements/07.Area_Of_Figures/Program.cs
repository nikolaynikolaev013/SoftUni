using System;

namespace Area_Of_Figures
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine($"{a * a:F3}");
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine($"{a * b:F3}");
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());

                Console.WriteLine($"{Math.PI * r * r:F3}");
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                Console.WriteLine($"{(a * h) / 2:F3}");
            }
        }
    }
}
