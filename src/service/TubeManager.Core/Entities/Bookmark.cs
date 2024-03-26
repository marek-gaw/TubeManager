namespace TubeManager.Core.Entities;

public class Bookmark
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string VideoUrl { get; set; }
    public string ThumbnailUrl { get; set; }
    public string Channel { get; set; }
    public string Description { get; set; }

    public Bookmark(Guid id, string _title, string _videoUrl, string _thumbnailUrl, string _channel, string _description)
    {
        Id = id;
        Title = _title;
        VideoUrl = _videoUrl;
        ThumbnailUrl = _thumbnailUrl;
        Channel = _channel;
        Description = _description;
    }
}