using System;
using _03.Raiding.Models;

namespace _03.Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IBaseHero CreateHero(string type, string name)
        {
            IBaseHero hero = null;

            switch (type)
            {
                case nameof(Druid):
                    hero = new Druid(name);
                    break;
                case nameof(Paladin):
                    hero = new Paladin(name);
                    break;
                case nameof(Rogue):
                    hero = new Rogue(name);
                    break;
                case nameof(Warrior):
                    hero = new Warrior(name);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
