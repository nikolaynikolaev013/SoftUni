using System;
namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;

        public Warrior(string name) : base(name)
        {
        }

        public override int Power => DefaultPower;
    }
}
