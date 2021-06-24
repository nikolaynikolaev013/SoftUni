using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bonus_scoring_system
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());
            int numOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = double.MinValue;
            int maxAttendance = 0;

            for (int i = 0; i < numOfStudents; i++)
            {
                int attendance = int.Parse(Console.ReadLine());
                double bonus = attendance * 1.0 / numOfLectures * (5 + additionalBonus);

                if (bonus > maxBonus)
                {
                    maxBonus = bonus;
                    maxAttendance = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(Math.Ceiling(maxBonus))}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}
