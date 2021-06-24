using System;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public PlayerFactory()
        {
        }

        public IPlayer CreatePlayer(string type, string username)
        {
            Enum.TryParse(type, out PlayerTypes typeEnum);

            IPlayer player = null;

            switch (typeEnum)
            {
                case PlayerTypes.Beginner:
                    player = new Beginner(new CardRepository(), username);
                    break;
                case PlayerTypes.Advanced:
                    player = new Advanced(new CardRepository(), username);
                    break;
            }

            return player;
        }
    }
}
