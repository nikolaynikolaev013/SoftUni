using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Enums;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
        }

        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(x => x.GetType().Name.ToString() == PlayerTypes.Terrorist.ToString()).ToList();
            var counterTerrorists = players.Where(x => x.GetType().Name.ToString() == PlayerTypes.CounterTerrorist.ToString()).ToList();

            while (terrorists.Any(x=>x.IsAlive) && counterTerrorists.Any(x=>x.IsAlive))
            {
                foreach (var terrorist in terrorists.Where(x=>x.IsAlive))
                {
                    foreach (var counterTerrorist in counterTerrorists.Where(x=>x.IsAlive))
                    {
                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }
                }
                foreach (var counterTerrorist in counterTerrorists.Where(x=>x.IsAlive))
                {
                    foreach (var terrorist in terrorists.Where(x=>x.IsAlive))
                    {
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            return terrorists.Any(x=>x.IsAlive) ? OutputMessages.TerroristsWon : OutputMessages.CounterTerroristsWon;
        }
    }
}
