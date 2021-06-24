using System;
namespace _03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int DefaultPower = 100;

        public Paladin(string name) : base(name)
        {
        }

        public override int Power => DefaultPower;
    }
}
