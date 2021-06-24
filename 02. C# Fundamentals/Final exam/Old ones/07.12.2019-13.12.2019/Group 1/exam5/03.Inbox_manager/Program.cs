using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inbox_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] command = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string user = String.Empty;

                switch (command[0])
                {
                    case "Add":
                        user = command[1];
                        if (users.ContainsKey(user))
                        {
                            Console.WriteLine($"{user} is already registered");
                            continue;
                        }

                        users.Add(user, new List<string> { });
                        break;

                    case "Send":
                        user = command[1];
                        string email = command[2];

                        if (users.ContainsKey(user))
                        {
                            users[user].Add(email);
                        }
                        break;

                    case "Delete":
                        user = command[1];

                        if (users.ContainsKey(user))
                        {
                            users.Remove(user);
                        }

                        else
                        {
                            Console.WriteLine($"{user} not found!");
                        }
                        break;
                }
            }

            Console.WriteLine($"Users count: {users.Count}");

            var sorted = users.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            foreach (var user in sorted)
            {
                Console.WriteLine(user.Key);
                foreach (var email in user.Value)
                {
                    Console.WriteLine($"- {email}");
                }
            }
        }
    }
}
