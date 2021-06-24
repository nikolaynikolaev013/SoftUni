using System;
using System.Collections.Generic;
using System.Linq;
using _03.Raiding.Factories;
using _03.Raiding.IO;
using _03.Raiding.Models;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IHeroFactory heroFactory;

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            List<IBaseHero> heroes = new List<IBaseHero>();

            var n = int.Parse(reader.Read());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var heroName = reader.Read();
                    var heroType = reader.Read();
                    heroes.Add(heroFactory.CreateHero(heroType, heroName));
                }
                catch (System.Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    i--;
                }
            }

            var bossPower = int.Parse(reader.Read());

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            string statusText = heroes.Sum(x => x.Power) >= bossPower ? "Victory!" : "Defeat...";

            writer.WriteLine(statusText);
        }
    }
}
