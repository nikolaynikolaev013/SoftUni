namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {

        private IPlayerRepository players;
        private ICardRepository cards;
        private IBattleField battleField;
        private ICardFactory cardFactory;
        private IPlayerFactory playerFactory;


        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
            this.battleField = new BattleField();
            this.cardFactory = new CardFactory();
            this.playerFactory = new PlayerFactory();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = playerFactory.CreatePlayer(type, username);
            players.Add(player);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, player.GetType().Name, player.Username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = cardFactory.CreateCard(type, name);

            this.cards.Add(card);
            return String.Format(ConstantMessages.SuccessfullyAddedCard, card.GetType().Name, card.Name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            this.players.Players.FirstOrDefault(x => x.Username == username).CardRepository.Add(this.cards.Cards.FirstOrDefault(x => x.Name == cardName));
            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackUserObj = this.players.Players.FirstOrDefault(x => x.Username == attackUser);
            IPlayer enemyUserObj = this.players.Players.FirstOrDefault(x => x.Username == enemyUser);
            battleField.Fight(attackUserObj,enemyUserObj);

            return String.Format(ConstantMessages.FightInfo, attackUserObj.Health, enemyUserObj.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.players.Players)
            {
                sb.AppendLine(String.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
