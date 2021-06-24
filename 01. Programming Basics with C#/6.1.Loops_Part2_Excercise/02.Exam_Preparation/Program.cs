using System;

namespace Exam_Preparation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int howMuchToFail = int.Parse(Console.ReadLine());

            string temp = Console.ReadLine();
            string name = "";
            double grade = double.Parse(Console.ReadLine());


            int gradesCounter = 0;
            double sum = 0;
            int poorCounter = 0;


            while (temp != "Enough")
            {

                if (temp != "Enough")
                {
                    name = temp;
                    sum += grade;

                    if (grade <= 4)
                    {
                        poorCounter++;
                    }

                    if (poorCounter >= howMuchToFail)
                    {
                        Console.WriteLine($"You need a break, {howMuchToFail} poor grades.");
                        break;
                    }


                    gradesCounter++;
                    temp = Console.ReadLine();
                    if (temp != "Enough")
                    {
                        grade = double.Parse(Console.ReadLine());
                    }
                }
            }

            if (poorCounter < howMuchToFail)
            {
                Console.WriteLine($"Average score: {sum/gradesCounter:F2}");
                Console.WriteLine($"Number of problems: {gradesCounter}");
                Console.WriteLine($"Last problem: {name}");
            }
        }
    }
}
