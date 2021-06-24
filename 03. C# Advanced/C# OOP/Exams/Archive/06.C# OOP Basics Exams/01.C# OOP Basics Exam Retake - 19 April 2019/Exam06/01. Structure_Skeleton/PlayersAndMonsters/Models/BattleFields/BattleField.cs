using System;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField :IBattleField
    {
        public BattleField()
        {
        }

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            BeginnersLuckBonus(attackPlayer);
            BeginnersLuckBonus(enemyPlayer);

            BonusHealthPoints(attackPlayer);
            BonusHealthPoints(enemyPlayer);

            bool attackerPlayerFirst = true;

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                if (attackerPlayerFirst)
                {
                    enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));
                }
                else
                {
                    attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));
                }

                attackerPlayerFirst = !attackerPlayerFirst;
            }
        }

        private static void BonusHealthPoints(IPlayer attackPlayer)
        {
            var bonus = attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            attackPlayer.Health += bonus;
        }

        private void BeginnersLuckBonus(IPlayer attackPlayer)
        {
            Enum.TryParse(attackPlayer.GetType().Name, out PlayerTypes attackplayerEnum);
            if (attackplayerEnum == PlayerTypes.Beginner)
            {
                attackPlayer.Health += 40;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
