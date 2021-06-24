namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			//			The given method in the project skeleton receives an array of genre names.Export all games in those genres, which have any purchases.For each genre, export its id, genre name, games and total players(total purchase count).For each game, export its id, name, developer, tags (separated by ", ") and total player count(purchase count). Order the games by player count(descending), then by game id(ascending).
			//Order the genres by total player count(descending), then by genre id(ascending)

			var games = context.Genres
				.Where(x => genreNames.Contains(x.Name))
				.ToList()
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games
					.Where(g => g.Purchases.Count > 0)
					.Select(g => new
					{
						Id = g.Id,
						Title = g.Name,
						Developer = g.Developer.Name,
						Tags = String.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
						Players = g.Purchases.Count
					})
					.OrderByDescending(p => p.Players)
					.ThenBy(g => g.Id)
					.ToList(),
					TotalPlayers = x.Games.Sum(g => g.Purchases.Count())

				})
				.OrderByDescending(x=>x.TotalPlayers)
				.ThenBy(x=>x.Id)
				.ToList();

			return JsonConvert.SerializeObject(games, Formatting.Indented);

			//"Id": 4,
   // "Genre": "Violent",
   // "Games": [

	  //{
			//	"Id": 49,
   //     "Title": "Warframe",
   //     "Developer": "Digital Extremes",
   //     "Tags": "Single-player, In-App Purchases, Steam Trading Cards, Co-op, Multi-player, Partial Controller Support",
   //     "Players": 6

	  //},

		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{

			//			Use the method provided in the project skeleton, which receives a purchase type as a string.Export all users who have any purchases.
            //		For each user, export their username, purchases for that purchase type and total money spent for that purchase type.For each purchase, export its card number, CVC, date in the format "yyyy-MM-dd HH:mm"(make sure you use CultureInfo.InvariantCulture) and the game.For each game, export its title(name), genre and price.Order the users by total spent(descending), then by username(ascending).For each user, order the purchases by date(ascending).Do not export users, who don’t have any purchases.
			//Note: All prices must be in decimal without any formatting!

			var purchases = context.Purchases;
			var users = context.Users
				.ToList()
				.Where(x => x.Cards
				.Any(c => c.Purchases.Any(p=>p.Type.ToString() == storeType)))
				.Select(x => new UsersExportModel
				{
					Username = x.Username,
					Purchases = x.Cards.SelectMany(p => p.Purchases)
					.Where(p=>p.Type.ToString() == storeType)
					.Select(p => new UserPurchaseExportModel
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new GameExportModel
						{
							Title = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
						}
					})
					.OrderBy(p=>p.Date)
					.ToArray(),
					TotalSpent = x.Cards.Sum(c => c.Purchases
						.Where(p => p.Type.ToString().ToLower() == storeType.ToLower())
						.Sum(p => p.Game.Price))
				})
				.OrderByDescending(x=>x.TotalSpent)
				.ThenBy(x=>x.Username)
				.ToList();


			return XmlConverter.Serialize(users, "Users");
		}
	}
}