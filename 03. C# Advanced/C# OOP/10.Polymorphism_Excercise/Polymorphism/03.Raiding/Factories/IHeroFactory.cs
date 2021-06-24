using System;
using _03.Raiding.Models;

namespace _03.Raiding.Factories
{
    public interface IHeroFactory
    {
        IBaseHero CreateHero(string type, string name);
    }
}
