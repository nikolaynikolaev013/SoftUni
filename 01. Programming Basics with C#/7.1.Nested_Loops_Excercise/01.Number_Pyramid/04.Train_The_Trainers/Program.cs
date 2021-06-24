using System;

namespace Train_The_Trainers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            string pName = "";
            double sum = 0;
            double finalSum = 0;
            double temp = 0;
            int counter = 0;

            string command = Console.ReadLine();

            while (command != "Finish")
            {
                pName = command;
                counter++;
                for (int i = 0; i < jury; i++)
                {
                    temp = double.Parse(Console.ReadLine());
                    sum += temp;
                }

                Console.WriteLine($"{pName} - {sum / jury:F2}.");
                finalSum += sum / jury;
                sum = 0;
                command = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {finalSum / counter :F2}.");
        }
    }
}
