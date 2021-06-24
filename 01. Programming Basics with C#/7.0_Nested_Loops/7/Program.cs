using System;

namespace Application
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            string movieName = "";
            int freeSeats = 0;
            string secondCommand = "";
            int student = 0;
            int standard = 0;
            int kids = 0;
            int counter = 0;
            int totalCounter = 0;

            while (command != "Finish")
            {
                counter = 0;
                movieName = command;
                freeSeats = int.Parse(Console.ReadLine());


                secondCommand = Console.ReadLine();

                while (secondCommand != "End")
                {
                    switch (secondCommand)
                    {
                        case "standard": standard++; break;
                        case "student": student++; break;
                        case "kid": kids++; break;
                    }
                    counter++;
                    totalCounter++;

                    if (counter == freeSeats)
                    {
                        Console.WriteLine($"{movieName} - {(100.0 / freeSeats) * counter:F2}% full.");
                        break;
                    }

                    secondCommand = Console.ReadLine();

                    if (secondCommand == "End")
                    {
                        Console.WriteLine($"{movieName} - {(100.0 / freeSeats) * counter:F2}% full.");
                        break;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalCounter}");
            Console.WriteLine($"{100.0 / (student + kids + standard) * student:F2}% student tickets.");
            Console.WriteLine($"{100.0 / (student + kids + standard) * standard:F2}% standard tickets.");
            Console.WriteLine($"{100.0 / (student + kids + standard) * kids:F2}% kids tickets.");
        }
    }
}
