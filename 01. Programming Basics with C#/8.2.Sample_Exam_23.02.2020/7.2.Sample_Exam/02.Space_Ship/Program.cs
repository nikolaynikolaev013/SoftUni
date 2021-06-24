using System;

namespace Space_Ship
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double avgHeight = double.Parse(Console.ReadLine());

            double rocketVolume = width * length * height;
            double roomVolume = (avgHeight + 0.4) * 2 * 2;

            int totalPassagers = (int)Math.Floor((rocketVolume / roomVolume));

            if (totalPassagers >=3 && totalPassagers <= 10)
            {
                Console.WriteLine($"The spacecraft holds {totalPassagers} astronauts.");
            }
            else if (totalPassagers < 3)
            {
                Console.WriteLine($"The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine($"The spacecraft is too big.");
            }
        }
    }
}
