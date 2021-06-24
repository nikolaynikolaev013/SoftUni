using System;
using System.Linq;

namespace _05.Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = coordinates[0];
            int cols = coordinates[1];

            var matrix = new string[rows, cols];

            string word = Console.ReadLine();

            int counter = 0;
            int wordCounter = 0;
            bool invert = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!invert)
                    {
                        matrix[row, col] = word[wordCounter].ToString();
                        counter++;
                        wordCounter++;

                        if (counter == cols)
                        {
                            invert = !invert;
                            counter = 0;
                        }
                    }
                    else if (invert)
                    {
                        matrix[row, cols - counter - 1] = word[wordCounter].ToString();
                        counter++;
                        wordCounter++;

                        if (counter == cols)
                        {
                            invert = !invert;
                            counter = 0;
                        }
                    }

                    if (wordCounter == word.Length)
                    {
                        wordCounter = 0;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
