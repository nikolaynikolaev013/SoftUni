using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();

            var users = new Dictionary<string, Dictionary<string, int>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] command = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (!contests.ContainsKey(command[0]) && command.Length == 2)
                {
                    contests.Add(command[0], command[1]);
                }
            }

            //"{contest}=>{password}=>{username}=>{points}" 

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] command = input.Split("=>");

                string contest = command[0];
                string pass = command[1];
                string user = command[2];
                int points = int.Parse(command[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == pass)
                    {
                        if (users.ContainsKey(user) )
                        {
                            if (users[user].ContainsKey(contest))
                            {
                                if (users[user][contest] < points)
                                {
                                    users[user][contest] = points;
                                }
                            }
                            else
                            {
                                users[user].Add(contest, points);
                            }
                        }
                        else
                        {
                            users.Add(user, new Dictionary<string, int>() {
                                { contest, points }
                            });
                        }
                    }
                }
            }
            //user {contest points}
            int counter = 0;

            foreach (var user in users.OrderBy(x=>x.Value.OrderBy(x=>x.Value)))
            {
                if (counter == 0)
                {
                    int totalPoints = 0;
                    foreach (var points in user.Value)
                    {
                        totalPoints += points.Value;
                    }
                    Console.WriteLine($"Best candidate is {user.Key} with total {totalPoints} points.");
                    counter++;
                }
            }
        }
    }
}
