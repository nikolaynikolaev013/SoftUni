using System;

namespace Fish_Tank
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double unavailableSpace = double.Parse(Console.ReadLine());

            double volume = (length * width * height) * 0.001;

            Console.WriteLine($"{volume - (volume * (unavailableSpace*0.01)):f3}");
        }
    }
}
