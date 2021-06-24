﻿using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private IList<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => (IReadOnlyCollection<ICard>)this.cards;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            if (this.Cards.Any(x=>x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            return this.Cards.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            return this.cards.Remove(card);
        }
    }
}
