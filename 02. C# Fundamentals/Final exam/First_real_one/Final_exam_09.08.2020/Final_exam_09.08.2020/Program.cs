using System;

namespace Final_exam_09._08._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string allStops = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] command = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Add Stop":
                        allStops = AddStop(allStops: allStops, command: command);
                        Console.WriteLine(allStops);
                        break;
                    case "Remove Stop":
                        allStops = RemoveStop(allStops: allStops, command: command);
                        Console.WriteLine(allStops);
                        break;
                    case "Switch":
                        allStops = Switch(allStops: allStops, command: command);
                        Console.WriteLine(allStops);
                        break;
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {allStops}");
        }

        private static string Switch(string allStops, string[] command)
        {
            string oldString = command[1];
            string newString = command[2];

            if (allStops.Contains(oldString))
            {
                allStops = allStops.Replace(oldString, newString);
            }

            return allStops;
        }

        private static string RemoveStop(string allStops, string[] command)
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]) + 1;
            if (startIndex >= 0 && endIndex >= 0 && startIndex < allStops.Length && endIndex < allStops.Length && startIndex <= endIndex)
            {
                allStops = allStops.Remove(startIndex, endIndex - startIndex);
            }

            return allStops;
        }

        private static string AddStop(string allStops, string[] command)
        {
            int index = int.Parse(command[1]);
            string stop = command[2];


            if (index >= 0 && index < allStops.Length)
            {
                allStops = allStops.Insert(index, stop);
            }

            return allStops;
        }
    }
}
