using System;

namespace Moving
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double l = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double cMeters = w * l * h;

            int numOfBoxes = 0;

            string temp = "";

            while (temp != "Done")
            {
                temp = Console.ReadLine();

                if (temp != "Done")
                {
                    numOfBoxes += int.Parse(temp);
                }

                if (cMeters < numOfBoxes)
                {
                    Console.WriteLine($"No more free space! You need {numOfBoxes - cMeters} Cubic meters more.");
                    break;
                }

                if (temp == "Done")
                {
                    Console.WriteLine($"{cMeters - numOfBoxes} Cubic meters left.");
                }
            }
        }
    }
}
