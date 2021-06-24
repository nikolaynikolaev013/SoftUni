using System;
namespace _03.Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract int Power { get; }

        public string CastAbility()
        {
            string msg = String.Empty;

            if (this.GetType().Name == nameof(Druid) || this.GetType().Name == nameof(Paladin))
            {
                msg = $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
            }
            else if (this.GetType().Name == nameof(Rogue) || this.GetType().Name == nameof(Warrior))
            {
                msg = $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
            }

            return msg;
        }
    }
}
