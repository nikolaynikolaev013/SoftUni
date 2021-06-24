using System;
namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int DefaultPower = 80;

        public Rogue(string name) : base(name)
        {
        }

        public override int Power => DefaultPower;
    }
}
