using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Enums;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<IGun> gunRepository;
        private IRepository<IPlayer> playerRepository;
        private IMap map;

        public Controller()
        {
            this.gunRepository = new GunRepository();
            this.playerRepository = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (!Enum.TryParse(type, out GunTypes gunType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            IGun gun = null;

            switch (gunType)
            {
                case GunTypes.Pistol:
                    gun = new Pistol(name, bulletsCount);
                    break;
                case GunTypes.Rifle:
                    gun = new Rifle(name, bulletsCount);
                    break;
            }

            this.gunRepository.Add(gun);

            return String.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.gunRepository.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (!Enum.TryParse(type, out PlayerTypes playerType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            IPlayer player = null;

            switch (playerType)
            {
                case PlayerTypes.Terrorist:
                    player = new Terrorist(username, health, armor, gun);
                    break;
                case PlayerTypes.CounterTerrorist:
                    player = new CounterTerrorist(username, health, armor, gun);
                    break;
            }

            this.playerRepository.Add(player);

            return String.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
        }

        public string Report()
        {
            return String.Join(Environment.NewLine, playerRepository.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Username).ToList());
        }

        public string StartGame()
        {
            return this.map.Start((ICollection<IPlayer>)playerRepository.Models);
        }
    }
}
