using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes
{
    public class HeroRepository
    {
        List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count { get { return this.data.Count; } }

        public void Add(Hero hero)
        {
            data.Add(hero);
        }

        public void Remove(string name)
        {
            data.Remove(data.FirstOrDefault(x => x.Name == name));
        }

        public Hero GetHeroWithHighestStrength()
        {
            return data.OrderByDescending(x=>x.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, this.data);
        }
    }
}
