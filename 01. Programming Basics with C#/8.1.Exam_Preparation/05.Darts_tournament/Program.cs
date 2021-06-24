using System;

namespace Darts_tournament
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int startPoints = int.Parse(Console.ReadLine());

            int amountOfPoints = 0;

            bool boolseye = false;

            int counter = 0;

            while (startPoints > 0)
            {
                string sector = Console.ReadLine();
                counter++;

                if (sector != "bullseye")
                {
                    amountOfPoints = int.Parse(Console.ReadLine());

                    if (sector == "number section")
                    {
                        startPoints -= amountOfPoints;
                    }
                    else if (sector == "double ring")
                    {
                        startPoints -= 2 * amountOfPoints;
                    }
                    else if (sector == "triple ring")
                    {
                        startPoints -= 3 * amountOfPoints;
                    }
                }
                else
                {
                    boolseye = true;
                    break;
                }
            }

            if (!boolseye && startPoints < 0)
            {
                Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(startPoints)}.");
            }
            else if (!boolseye && startPoints == 0)
            {
                Console.WriteLine($"Congratulations! You won the game in {counter} moves!");
            }
            else if (boolseye)
            {
                Console.WriteLine($"Congratulations! You won the game with a bullseye in {counter} moves!");
            }
        }
    }
}
