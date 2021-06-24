using System;
using System.Numerics;

namespace _11.Snow_balls
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            ushort snowballSnow = 0;
            short snowballTime = 0;
            byte snowballQuality = 0;

            BigInteger calculated = 0;

            BigInteger bestBall = int.MinValue;
            ushort bestBallSnow = 0;
            short bestBallTime = 0;
            byte bestBallQuality = 0;

            for (int i = 0; i < n; i++)
            {
                snowballSnow = ushort.Parse(Console.ReadLine());
                snowballTime = short.Parse(Console.ReadLine());
                snowballQuality = byte.Parse(Console.ReadLine());

                calculated = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (bestBall <= calculated || i == 0)
                {
                    bestBall = calculated;
                    bestBallSnow = snowballSnow;
                    bestBallTime = snowballTime;
                    bestBallQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{bestBallSnow} : {bestBallTime} = {bestBall} ({bestBallQuality})");
 
        }
    }
}
