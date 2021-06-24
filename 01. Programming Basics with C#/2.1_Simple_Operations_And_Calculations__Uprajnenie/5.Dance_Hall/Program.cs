using System;

namespace Dance_Hall
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());

            double hall = (L*100) * (W*100);
            double bench = hall / 10; 
            double wardrobe = (A*100) * (A*100); 
            double availableSpace = hall - bench - wardrobe;
            double dancers = availableSpace / 7040;

            Console.WriteLine(Math.Floor(dancers));
        }
    }
}
