using System.Globalization;
using System.IO.Compression;
using System.Threading.Channels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TubeManager.Core.Entities;
using TubeManager.Infrastructure.DataAccessLayer;
using TubeManager.Infrastructure.Models;

namespace TubeManager.Infrastructure.Services;

internal sealed class BackupImporter : BackgroundService
{
    private readonly IServiceProvider _serviceProviders;
    private readonly ChannelReader<string> _channel;

    public BackupImporter(IServiceProvider serviceProviders, ChannelReader<string> channel)
    {
        _serviceProviders = serviceProviders;
        _channel = channel;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        //TODO: implement fetching data from the database
        // 1. Receive file from controller via channels
        // const string archivePath = "../../../skytube-2023-08-18-180651.skytube";
        await foreach (var item in _channel.ReadAllAsync(cancellationToken))
        {
            DoIt(item.ToString());
        }
    }

    private void DoIt(string archivePath)
    {
        using var scope = _serviceProviders.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BookmarksDbContext>();

        DateTime df = DateTime.Now;
        string extractTo = Path.GetTempPath() + df.ToString("u", CultureInfo.CurrentCulture);
        ZipFile.ExtractToDirectory(archivePath, extractTo);

        // 2. Read data from bookmarks.db
        var contextOptions = new DbContextOptionsBuilder<ImportedDbContext>()
            .UseSqlite($@"DataSource={extractTo}/bookmarks.db")
            .Options;

        using (var context = new ImportedDbContext(contextOptions))
        {
            var bookmarks = context.Bookmarks.ToList();

            foreach (var bookmark in bookmarks)
            {
                string decodedBytes = System.Text.Encoding.UTF8.GetString(bookmark.YouTubeVideo);

                var values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(decodedBytes);

                JObject ob = JObject.Parse(decodedBytes);

                ScaffoldedVideo video = new ScaffoldedVideo((string)values["duration"],
                    (long)values["durationInSeconds"],
                    (bool)values["isLiveStream"],
                    (string)values["thumbnailMaxResUrl"],
                    (string)values["id"],
                    (string)values["thumbnailUrl"],
                    (string)values["title"]
                );

                var ChannelTitle = ob["channel"]["title"];

                string description = "";
                try
                {
                    description = (string)ob["description"];
                }
                catch
                {
                    Console.WriteLine("There is no description for this video");
                    description = "No description";
                }

                //var channel = JsonConvert.DeserializeObject<Dictionary<string, Object>>(values["channel"]); 
                //var channel = values["channel"];
                //var title = channel.Parse
                //Channel channel= new Channel()

                //TODO: make this an option
                //skip if this entry already exists.
                if ((dbContext.Bookmarks.FirstOrDefault(b => b.VideoUrl == video.Id)) is not null) continue;

                // TODO: add new
                Bookmark b = new Bookmark(Guid.NewGuid(),
                    video.Title,
                    bookmark.YouTubeVideoId,
                    video.ThumbnailUrl,
                    (string)ChannelTitle,
                    description ?? "No description for this video...");

                dbContext.Bookmarks.Add(b);

                //TODO: make this an option
                //update fields
                //var bookmarkToUpdate = dbContext.Bookmarks.SingleOrDefault(ba => ba.VideoUrl == bookmark.YouTubeVideoId);
                //bookmarkToUpdate.Title = video.Title;
                //bookmarkToUpdate.Description = description ?? "No description available" ;
            }

            dbContext.SaveChanges();
        }
    }
}