using System;
using _03.Raiding.Core;
using _03.Raiding.Factories;
using _03.Raiding.IO;

namespace _03.Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IHeroFactory heroFactory = new HeroFactory();
            Engine engine = new Engine(reader, writer, heroFactory);
            engine.Run();
            

        }
    }
}
