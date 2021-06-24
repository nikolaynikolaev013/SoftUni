using System;

namespace _08.Beer_kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKeg = String.Empty;
            double biggestKegVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                if (Math.PI * Math.Pow(radius, 2) * height > biggestKegVolume)
                {
                    biggestKegVolume = Math.PI * Math.Pow(radius, 2) * height;
                    biggestKeg = model;
                }
            }
            Console.WriteLine(biggestKeg);

        }
    }
}
