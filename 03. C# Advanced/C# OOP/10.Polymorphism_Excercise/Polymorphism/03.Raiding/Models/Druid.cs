using System;
namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DefaultPower = 80;

        public Druid(string name) : base(name)
        {
        }

        public override int Power => DefaultPower;
    }
}
