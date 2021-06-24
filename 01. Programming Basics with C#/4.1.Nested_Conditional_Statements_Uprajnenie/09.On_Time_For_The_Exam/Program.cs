using System;

namespace On_Time_For_The_Exam
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int examH = int.Parse(Console.ReadLine());
            int examM = int.Parse(Console.ReadLine());
            int arriveH = int.Parse(Console.ReadLine());
            int arriveM = int.Parse(Console.ReadLine());

            int examTotal = examH * 60 + examM;
            int arriveTotal = arriveH * 60 + arriveM;

            if (arriveTotal > examTotal)
            {
                Console.WriteLine("Late");
                if (arriveTotal - examTotal < 60)
                {
                    Console.WriteLine($"{arriveTotal - examTotal} minutes after the start");
                }
                else if (arriveTotal - examTotal >= 60)
                {
                    Console.WriteLine($"{arriveH - examH}:{arriveTotal - examTotal - ((arriveH - examH) * 60):D2} hours after the start");
                }
            }
            else if (arriveTotal == examTotal || examTotal - arriveTotal <= 30)
            {
                Console.WriteLine("On time");

                if (arriveTotal != examTotal)
                {
                    Console.WriteLine($"{examTotal - arriveTotal} minutes before the start");
                }
            }
            else if (examTotal - arriveTotal > 30)
            {
                Console.WriteLine("Early");

                if (examTotal - arriveTotal < 60)
                {
                    Console.WriteLine($"{examTotal - arriveTotal} minutes before the start");
                }
                else if (examTotal - arriveTotal - ((examH - arriveH) * 60) < 0)
                {
                    Console.WriteLine($"{examH - arriveH}:{examTotal - arriveTotal - ((examH - arriveH - 1) * 60):D2} hours before the start");
                }
                else if (examTotal - arriveTotal >= 60)
                {
                    Console.WriteLine($"{examH - arriveH}:{examTotal - arriveTotal - ((examH - arriveH) * 60):D2} hours before the start");
                }
                //1410       580 830 
            }
        }
    }
}
