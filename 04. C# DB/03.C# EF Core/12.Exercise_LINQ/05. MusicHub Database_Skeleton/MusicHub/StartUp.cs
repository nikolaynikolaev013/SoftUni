namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Producers
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(a => new
                {
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            Name = s.Name,
                            Price = decimal.Parse(s.Price.ToString("F2")),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(w => w.Writer)
                        .ToList(),
                    TotalAlbumPrice = decimal.Parse(a.Price.ToString("F2"))
                })
                .OrderByDescending(a => a.TotalAlbumPrice)
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                var counter = 0;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{++counter}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.Writer}");

                }
                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");


            }
            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            //Export the songs which are above the given duration.For each Song, export its Name, Performer Full Name, Writer Name, Album Producer and Duration(in format("c")).Sort the Songs by their Name(ascending), by Writer(ascending) and by Performer(ascending).
            var songs = context.Songs
                .Where(x => x.Duration > new TimeSpan(0, 0, duration))
                .Select(x => new
                {
                    Name = x.Name,
                    PerformerName = x.SongPerformers.Select(x => x.Performer.FirstName + " " + x.Performer.LastName).FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                })
                .OrderBy(x=>x.Name)
                .ThenBy(x=>x.WriterName)
                .ThenBy(x=>x.PerformerName)
                .ToList();

            var sb = new StringBuilder();

            var counter = 0;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{++counter}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().Trim();
        }
    }
}
