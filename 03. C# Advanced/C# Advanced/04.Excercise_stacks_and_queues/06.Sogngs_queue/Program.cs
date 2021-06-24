using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Sogngs_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var songsQueue = new Queue<string>(songs);

            
            while (songsQueue.Any())
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Add":

                        StringBuilder songName = new StringBuilder();
                        foreach (var item in command)
                        {
                            if (item == "Add")
                            {
                                continue;
                            }
                            songName.Append(item + " ");
                        }

                        if (songsQueue.Contains(songName.ToString().Trim()))
                        {
                            Console.WriteLine($"{songName.ToString().Trim()} is already contained!");
                        }
                        else
                        {
                            songsQueue.Enqueue(songName.ToString().Trim());
                        }
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", songsQueue));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
