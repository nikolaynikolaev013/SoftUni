using System;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public CardFactory()
        {
        }

        public ICard CreateCard(string type, string name)
        {
            Enum.TryParse(type, out CardTypes typeEnum);

            ICard card = null;

            switch (typeEnum)
            {
                case CardTypes.Magic:
                    card = new MagicCard(name);
                    break;
                case CardTypes.Trap:
                    card = new TrapCard(name);
                    break;
                default:
                    break;
            }

            return card;
        }
    }
}
