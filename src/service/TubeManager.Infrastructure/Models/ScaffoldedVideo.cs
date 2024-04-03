namespace TubeManager.Infrastructure.Models;

public record ScaffoldedVideo(string Duration,
    long DurationInSeconds,
    bool IsLiveStream,
    string ThumbnailMaxResUrl,
    string Id,
    string ThumbnailUrl,
    string Title
);

