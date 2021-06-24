namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			//The given method in the project skeleton receives an array of genre names. Export all games in those genres, which have any purchases. For each genre, export its id, genre name, games and total players (total purchase count). For each game, export its id, name, developer, tags (separated by ", ") and total player count (purchase count). Order the games by player count (descending), then by game id (ascending).
			//Order the genres by total player count(descending), then by genre id(ascending)

			var games = context.Genres
				.ToList()
				.Where(x => genreNames.Contains(x.Name))
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games
						.Where(g => g.Purchases.Count > 0)
						.Select(g => new {
							Id = g.Id,
							Title = g.Name,
							Developer = g.Developer.Name,
							Tags = String.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
							Players = g.Purchases.Count
						})
						.OrderByDescending(g=>g.Players)
						.ThenBy(g=>g.Id)
						.ToList(),
					TotalPlayers = x.Games.Where(g=>g.Purchases.Count > 0).Sum(g=>g.Purchases.Count)
				})
				.OrderByDescending(x=>x.TotalPlayers)
				.ThenBy(x=>x.Id)
				.ToList();

			return JsonConvert.SerializeObject(games, Formatting.Indented);
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			//Use the method provided in the project skeleton, which receives a purchase type as a string.Export all users who have any purchases.
			//For each user, export their username, purchases for that purchase type and total money spent for that purchase type.For each purchase, export its card number, CVC, date in the format "yyyy-MM-dd HH:mm"(make sure you use CultureInfo.InvariantCulture) and the game.For each game, export its title(name), genre and price.Order the users by total spent(descending), then by username(ascending).For each user, order the purchases by date(ascending).Do not export users, who don’t have any purchases.
			//Note: All prices must be in decimal without any formatting!

			var users = context.Users
				.ToList()
				.Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type == Enum.Parse<PurchaseType>(storeType))))
				.Select(x => new UsersXmlExportModel {
					Username = x.Username,
					Purchases = x.Cards.SelectMany(c => c.Purchases)
					.Where(c=>c.Type == Enum.Parse<PurchaseType>(storeType))
					.Select(p => new UserPurchaseExportModel {
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm"),
						Game = new GameXmlExportModel {
							Title = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
						}
					})
					.ToArray()
				})
				.ToArray();

			return XmlConverter.Serialize(users, "Users");
		}
	}
}