using System;

namespace Vacation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            double temp = 0;
            int spendingCounter = 0;
            int daysCounter = 0;

            while (true)
            {
                daysCounter++;

                string command = Console.ReadLine();
                temp = double.Parse(Console.ReadLine());

                if (command == "spend")
                {
                    spendingCounter++;
                    availableMoney -= temp;
                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }
                }
                else if (command == "save")
                {
                    spendingCounter = 0;
                    availableMoney += temp;
                }

                if (availableMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {daysCounter} days.");
                    break;
                }
                else if (spendingCounter >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(daysCounter);
                    break;

                }
            }
        }
    }
}
