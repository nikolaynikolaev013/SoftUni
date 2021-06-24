using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        List<Player> roaster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            roaster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => roaster.Count; }

        public void AddPlayer(Player player)
        {
            if (this.Count < Capacity)
            {
                roaster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roaster.Remove(roaster.FirstOrDefault(x => x.Name == name));
        }

        public void PromotePlayer(string name)
        {
            if (roaster.Any(x=>x.Name == name))
            {
                roaster.FirstOrDefault(x => x.Name == name).Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roaster.Any(x=>x.Name == name))
            {
                roaster.FirstOrDefault(x => x.Name == name).Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string Class) {
            Player[] removedPlayers = roaster.Where(x=>x.Class == Class).ToArray();

            roaster.RemoveAll(x=>x.Class == Class);
            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            sb.AppendLine(String.Join(Environment.NewLine, roaster));

            return sb.ToString().TrimEnd();
        }
    }
}
