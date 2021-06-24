using System;

namespace Exam
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double skumriq = double.Parse(Console.ReadLine());
            double caca = double.Parse(Console.ReadLine());
            double palamudAmount = double.Parse(Console.ReadLine());
            double safridAmount = double.Parse(Console.ReadLine());
            double midiAmount = double.Parse(Console.ReadLine());

            double palamudPrice = skumriq * 1.60;
            double safridPrice = caca * 1.80;
            double midiPrice = 7.50;

            double finalPrice = (palamudPrice * palamudAmount) + (safridAmount * safridPrice) + (midiAmount * midiPrice);

            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
