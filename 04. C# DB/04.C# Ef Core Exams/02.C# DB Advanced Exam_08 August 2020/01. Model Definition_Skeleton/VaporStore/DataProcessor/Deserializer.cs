namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var gamesDto = JsonConvert.DeserializeObject<IEnumerable<GamesImportModel>>(jsonString);
			var games = new List<Game>();

			var sb = new StringBuilder();
            //•	If any validation errors occur (such as if a Price is negative, a Name/ReleaseDate/Developer/Genre is missing, Tags are missing or empty), do not import any part of the entity and append an error message to the method output.
            //•	Dates are always in the format “yyyy - MM - dd”. Do not forget to use CultureInfo.InvariantCulture!
            //•	If a developer / genre / tag with that name doesn’t exist, create it.
            //•	If a game is invalid, do not import its genre, developer or tags.

            foreach (var game in gamesDto)
            {
                if (!IsValid(game) ||
					!game.Tags.Any() )
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var currGame = new Game
				{
					Name = game.Name,
					Price = game.Price,
					ReleaseDate = game.ReleaseDate.Value,
					Developer = context.Developers.FirstOrDefault(x=>x.Name == game.Developer) ?? new Developer { Name = game.Developer },
					Genre = context.Genres.FirstOrDefault(x => x.Name == game.Genre)
							?? new Genre { Name = game.Genre }
			};

                foreach (var jsonTag in game.Tags)
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag) ?? new Tag { Name = jsonTag };
					currGame.GameTags.Add(new GameTag { Tag = tag});
                }
				sb.AppendLine($"Added {game.Name} ({game.Genre}) with {game.Tags.Count()} tags");

				context.Games.Add(currGame);
				context.SaveChanges();
            }
			return sb.ToString().Trim();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			//•	If any validation errors occur(such as invalid full name, too short / long username, missing email, too low / high age, incorrect card number / CVC, no cards, etc.), do not import any part of the entity and append an error message to the method output.
			//•	If any validation errors occur with card entity(such as invalid number / CVC, invalid Type) you should not import any part of the User entity holding this card and append an error message to the method output. 

			var sb = new StringBuilder();

			var usersDto = JsonConvert.DeserializeObject<IEnumerable<UsersImportModel>>(jsonString);
			var users = new List<User>();

            foreach (var user in usersDto)
            {
                if (!IsValid(user) ||
					!user.Cards.Any(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");

				var currUser = new User
				{
					FullName = user.FullName,
					Username = user.Username,
					Email = user.Email,
					Age = user.Age
				};

                foreach (var card in user.Cards)
                {
					var currCard = new Card
					{
						Number = card.Number,
						Cvc = card.Cvc,
						Type = Enum.Parse<CardType>(card.Type)
					};

					currUser.Cards.Add(currCard);
                }

				users.Add(currUser);
            }

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
//•	If there are any validation errors, do not import any part of the entity and append an error message to the method output.
//•	Dates will always be in the format: “dd / MM / yyyy HH: mm”. Do not forget to use CultureInfo.InvariantCulture!

			var sb = new StringBuilder();
			var porchasesDto = XmlConverter.Deserializer<PurchasesImportModel>(xmlString, "Purchases");
			var purchases = new List<Purchase>();

            foreach (var purchase in porchasesDto)
            {
                if (!IsValid(purchase))
                {
					sb.AppendLine("Invalid Data");
                }

				var card = context.Cards.FirstOrDefault(x => x.Number == purchase.Card);
				var date = DateTime.ParseExact(purchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
				var game = context.Games.FirstOrDefault(x => x.Name == purchase.Title);

				var currPurchase = new Purchase
				{
					ProductKey = purchase.Key,
					Card = card,
					Date = date,
					Game = game,
					Type = Enum.Parse<PurchaseType>(purchase.Type)
				};
				var users = context.Users.ToList();
				var user = users.FirstOrDefault(x => x.Id == card.UserId);
				sb.AppendLine($"Imported {purchase.Title} for {user.Username}");

				purchases.Add(currPurchase);
            }

			context.Purchases.AddRange(purchases);
			context.SaveChanges();
			return sb.ToString().Trim();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}