using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            string input = String.Empty;

            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine();
                string[] command = input.Split("-").ToArray();

                string teamName = command[1].ToString();
                string creatorName = command[0].ToString();

                if (teams.Any(x=>x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(x=>x.TeamOwner == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                teams.Add(new Team(teamName, creatorName));
            }

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] command = input.Split("->");

                string teamName = command[1].ToString();
                string user = command[0].ToString();

                if (!teams.Any(x=>x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }
                else if (teams.Any(x=>x.Members.Contains(user)) || teams.Any(x=>x.TeamOwner == user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                int index = teams.IndexOf(teams.Find(x => x.TeamName == teamName));
                teams[index].Members.Add(user);
            }

            var disband = teams.FindAll(x => x.Members.Count == 0).OrderBy(x=>x.TeamName);
            var validTeams = teams.FindAll(x => x.Members.Count > 0).OrderBy(x=>x.TeamName);

            

            Console.WriteLine(String.Join(Environment.NewLine, validTeams.OrderByDescending(x=>x.Members.Count).ThenBy(x=>x.TeamName)));

            Console.WriteLine("Teams to disband:");
            Console.WriteLine(String.Join(Environment.NewLine, disband.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).Select(x=>x.TeamName)));
        }

    }


    class Team
    {
        public string TeamName { get; set; }
        public string TeamOwner { get; set; }
        public List<string> Members { get; set; }

        public Team(string teamName, string creatorName)
        {
            this.TeamName = teamName;
            this.TeamOwner = creatorName;
            this.Members = new List<string>();
            Console.WriteLine($"Team {TeamName} has been created by {TeamOwner}!");
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(TeamName);
            str.Append(Environment.NewLine + "- " + TeamOwner);

            foreach (var member in Members)
            {
                str.Append(Environment.NewLine + "-- " + member);
            }
            return str.ToString();
        }
    }
}
