using spike_db_scaffold;
using spike_db_scaffold.Model;
using System.IO;
using System.Text;
using Newtonsoft.Json;

using (var context = new BookmarksContext())
{
    foreach (var bookmark in context.Bookmarks)
    {
        string decodedBytes = System.Text.Encoding.UTF8.GetString(bookmark.YouTubeVideo);
        
        var values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(decodedBytes);
        var channel = JsonConvert.DeserializeObject<Channel>(values["channel"].ToString());
        values.Remove("channel");

        Video video = new Video((string)values["duration"],
            (long)values["durationInSeconds"],
            (bool)values["isLiveStream"],
            (string)values["thumbnailMaxResUrl"],
            (string)values["id"],
            (Int64)values["publishTimestamp"],    
            (string)values["thumbnailUrl"],
            (string)values["title"]
        );  
        Console.WriteLine($"{channel.Title}: {video.Title}");
    }
}

public record Video(string Duration,
    long DurationInSeconds,
    bool IsLiveStream,
    string ThumbnailMaxResUrl,
    string Id,
    long PublishTimestamp,
    string ThumbnailUrl,
    string Title
    );
public record Channel(string BannerUrl,
    string IsUserSubscribed,
    string LastCheckTime,
    string LastVideoTime,
    string LastVisitTime,
    string SubscriberCount,
    string TotalSubscribers,
    List<string> YouTubeVideos,
    string Description,
    string Id,
    string PublishTimestampExact,
    string ThumbnailUrl,
    string Title
    );
    