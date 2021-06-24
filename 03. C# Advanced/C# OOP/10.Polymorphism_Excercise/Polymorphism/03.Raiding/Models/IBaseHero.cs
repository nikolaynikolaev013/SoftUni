using System;
namespace _03.Raiding.Models
{
    public interface IBaseHero
    {
        string Name { get; }
        abstract int Power { get; }

        string CastAbility();
    }
}
