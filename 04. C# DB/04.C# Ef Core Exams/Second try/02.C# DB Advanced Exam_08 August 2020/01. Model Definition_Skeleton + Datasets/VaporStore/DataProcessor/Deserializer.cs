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
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			//•	If any validation errors occur(such as if a Price is negative, a Name/ ReleaseDate / Developer / Genre is missing, Tags are missing or empty), do not import any part of the entity and append an error message to the method output.
			//•	Dates are always in the format “yyyy - MM - dd”. Do not forget to use CultureInfo.InvariantCulture!
			//•	If a developer / genre / tag with that name doesn’t exist, create it.
			//•	If a game is invalid, do not import its genre, developer or tags.

			var sb = new StringBuilder();
			var gamesDto = JsonConvert.DeserializeObject<GamesTagsJsonImportModel[]>(jsonString);

            foreach (var game in gamesDto)
            {
                if (!IsValid(game) ||
					!game.Tags.Any())
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var currGame = new Game
				{
					Name = game.Name,
					Price = game.Price,
					ReleaseDate = DateTime.ParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
					Genre = context.Genres.FirstOrDefault(x => x.Name == game.Genre)
								?? new Genre { Name = game.Genre },
					Developer = context.Developers.FirstOrDefault(x => x.Name == game.Developer)
								?? new Developer { Name = game.Developer }
				};

                foreach (var tag in game.Tags)
                {
					var currTag = context.Tags.FirstOrDefault(x => x.Name == tag) ?? new Tag { Name = tag };
					currGame.GameTags.Add(new GameTag { Tag = currTag });
                }
				sb.AppendLine($"Added {currGame.Name} ({currGame.Genre.Name}) with {currGame.GameTags.Count} tags");
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
			var usersDto = JsonConvert.DeserializeObject<UsersJsonImportModel[]>(jsonString);
			var usersToImport = new List<User>();

            foreach (var user in usersDto)
            {
                if (!IsValid(user) ||
					!user.Cards.Any() ||
					!user.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

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
						Cvc = card.Number,
						Type = Enum.Parse<CardType>(card.Type)
					};
					currUser.Cards.Add(currCard);
                }

				sb.AppendLine($"Imported {currUser.Username} with {currUser.Cards.Count} cards");
				usersToImport.Add(currUser);
            }

			context.Users.AddRange(usersToImport);
			context.SaveChanges();
			return sb.ToString().Trim();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			//•	If there are any validation errors, do not import any part of the entity and append an error message to the method output.
			//•	Dates will always be in the format: “dd / MM / yyyy HH: mm”. Do not forget to use CultureInfo.InvariantCulture!

			var sb = new StringBuilder();
			var purchasesDto = XmlConverter.Deserializer<PurchasesXmlImportModel>(xmlString, "Purchases");
			var purchasesToImport = new List<Purchase>();

            foreach (var purchase in purchasesDto)
            {
                if (!IsValid(purchase))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var currUser = context.Users.FirstOrDefault(x => x.Cards.Select(c => c.Number).Contains(purchase.CardNumber));
				var game = context.Games.FirstOrDefault(x => x.Name == purchase.GameName);


				var currPurchase = new Purchase
				{
					Type = Enum.Parse<PurchaseType>(purchase.Type),
					ProductKey = purchase.ProductKey,
					Date = DateTime.ParseExact(purchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Card = currUser.Cards.FirstOrDefault(x => x.Number == purchase.CardNumber),
					Game = game
				};
				sb.AppendLine($"Imported {currPurchase.Game.Name} for {currUser.Username}");
				purchasesToImport.Add(currPurchase);
            }


			context.Purchases.AddRange(purchasesToImport);
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