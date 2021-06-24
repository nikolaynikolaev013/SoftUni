using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private object myProperty;
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get => baseHealth; set => baseHealth = value; }

        public double Health
        {
            get => this.health;
            set
            {
                if (!(value < 0 || value > this.BaseHealth))
                {
                    this.health = value;
                }
                else if (this.health - value <= 0)
                {
                    this.IsAlive = false;
                    this.health = 0;
                }
            }
        }

        public double BaseArmor { get => baseArmor; set => baseArmor = value; }

        public double Armor
        {
            get => armor;
            set
            {
                if (value > 0)
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get => abilityPoints; set => abilityPoints = value; }

        public Bag Bag { get => bag; set => bag = value; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.Armor - hitPoints < 0)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;
            }
            else
            {
                this.Armor -= hitPoints;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}