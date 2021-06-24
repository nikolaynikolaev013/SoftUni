using System;

namespace Loops_Part2_Excercise
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string favbook = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());
            int counter = 0;

            string currentBook = Console.ReadLine();

            while (favbook != currentBook)
            {
                counter++;
                if (counter == capacity)
                {
                    break;
                }

                currentBook = Console.ReadLine();

            }
            if (currentBook == favbook)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {capacity} books.");
            }
        }
    }
}
