namespace TubeManager.Core.Entities;

public class Bookmark
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string VideoUrl { get; set; }
    public string ThumbnailUrl { get; set; }
    public string Channel { get; set; }
    public string Description { get; set; }

    public Bookmark(Guid id, string title, string videoUrl, string thumbnailUrl, string channel, string description)
    {
        Id = id;
        Title = title;
        VideoUrl = videoUrl;
        ThumbnailUrl = thumbnailUrl;
        Channel = channel;
        Description = description;
    }
    
    public Bookmark( string title, string videoUrl, string thumbnailUrl, string channel, string description)
    {
        Title = title;
        VideoUrl = videoUrl;
        ThumbnailUrl = thumbnailUrl;
        Channel = channel;
        Description = description;
    }
}