using System;

namespace Back_in_30
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int newHour = hour;
            int newMinutes = minutes + 30;

            if (newMinutes > 60 && newHour + 1 > 23)
            {
                newMinutes -= 60;
                newHour = 0;
            }
            else if (newMinutes > 60)
            {
                newMinutes -= 60;
                newHour++;
            }

            Console.WriteLine($"{newHour}:{newMinutes:D2}");
        }
    }
}
