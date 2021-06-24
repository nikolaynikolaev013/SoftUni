using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
    public class PlayerRepository : IPlayerRepository
    {
        private IList<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public int Count => Players.Count;

        public IReadOnlyCollection<IPlayer> Players => (IReadOnlyCollection<IPlayer>)this.players;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.Players.Any(x=>x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.Players.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            return this.players.Remove(player);
        }
    }
}
