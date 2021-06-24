using System;
using System.Linq;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IManagerController managerController;

        public Engine(IWriter writer, IReader reader, IManagerController mc)
        {
            this.writer = writer;
            this.reader = reader;
            this.managerController = mc;
        }

        public void Run()
        {
            while (true)
            {
                var command = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {

                    switch (command[0])
                    {
                        case "AddPlayer":
                            var playerType = command[1];
                            var username = command[2];
                            this.writer.WriteLine(this.managerController.AddPlayer(playerType, username));
                            break;
                        case "AddCard":
                            var cardType = command[1];
                            var name = command[2];
                            this.writer.WriteLine(this.managerController.AddCard(cardType, name));
                            break;
                        case "AddPlayerCard":
                            var playerUsername = command[1];
                            var cardName = command[2];
                            this.writer.WriteLine(this.managerController.AddPlayerCard(playerUsername, cardName));
                            break;
                        case "Fight":
                            var attackUser = command[1];
                            var enemyUser = command[2];
                            this.writer.WriteLine(this.managerController.Fight(attackUser, enemyUser));
                            break;
                        case "Report":
                            this.writer.WriteLine(this.managerController.Report());
                            break;
                        case "Exit":
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

        }
    }
}
