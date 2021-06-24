using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double DefaultHealth = 50;
        private const double DefaultArmor = 25;
        private const double DefaultAbilityPoints = 40;

        public Priest(string name) : base(name, DefaultHealth, DefaultArmor, DefaultArmor, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (character == this)
            {
                //TODO
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
