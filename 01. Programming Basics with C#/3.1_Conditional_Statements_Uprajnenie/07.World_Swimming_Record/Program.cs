using System;

namespace World_Swimming_Record
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine()); //1000 - trqbwa da promeni
            double distance = double.Parse(Console.ReadLine()); //200
            double secondsFor1M = double.Parse(Console.ReadLine()); //5

            double waterResistance = Math.Floor(distance / 15) * 12.5;
            double newRecord = distance * secondsFor1M + waterResistance;


            if (record <= newRecord)
            {
                Console.WriteLine($"No, he failed! He was {newRecord - record:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {newRecord:F2} seconds.");
            }
        }
    }
}
