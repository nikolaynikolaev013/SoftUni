using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, List<string>>> ();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[1] == "joined")
                {
                    string vlogger = command[0];

                    if (!vloggers.ContainsKey(vlogger))
                    {
                        vloggers.Add(vlogger, new Dictionary<string, List<string>> (){
                            {"followers", new List<string>()},
                            {"following", new List<string>()}
                        });
                    }

                }
                else if (command[1] == "followed")
                {
                    string vlogger = command[0];
                    string vloggerToFollow = command[2];

                    if (vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(vloggerToFollow) && vlogger != vloggerToFollow)
                    {
                        if (!vloggers[vloggerToFollow]["followers"].Contains(vlogger))
                        {
                            vloggers[vloggerToFollow]["followers"].Add(vlogger);
                            vloggers[vlogger]["following"].Add(vloggerToFollow);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            if (vloggers.Any())
            {
                

                int counter = 1;

                foreach (var vlogger in vloggers.OrderByDescending(x=>x.Value["followers"].Count).ThenBy(x=>x.Value["following"].Count))
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                    if (counter == 1)
                    {
                        foreach (var follower in vloggers[vlogger.Key]["followers"].OrderBy(x => x))
                        {
                            Console.WriteLine($"*  {follower}");
                        }
                    }
                    counter++;
                }
            }
        }
    }
}
