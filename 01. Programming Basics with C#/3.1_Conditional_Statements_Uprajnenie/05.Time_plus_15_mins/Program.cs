using System;

namespace Time_plus_15_mins
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            seconds += 15;

            if (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }

            if (minutes > 23)
            {
                minutes -= 24;
            }


            Console.WriteLine($"{minutes}:{seconds:D2}");
        }
    }
}
