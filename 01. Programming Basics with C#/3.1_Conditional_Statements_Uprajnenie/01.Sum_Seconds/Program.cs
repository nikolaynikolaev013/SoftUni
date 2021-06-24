using System;

namespace Sum_Seconds
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int sumSeconds = first + second + third;

            Console.WriteLine($"{sumSeconds/60}:{sumSeconds%60:D2}");
        }
    }
}
