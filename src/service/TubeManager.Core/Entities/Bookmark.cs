using TubeManager.Core.DTO;
using TubeManager.Core.ValueObjects;

namespace TubeManager.Core.Entities;

public sealed class Bookmark
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public Url VideoUrl { get; set; }
    public Url ThumbnailUrl { get; set; }
    public string Channel { get; set; }
    public string Description { get; set; }
    public List<Tag> Tags { get; } = [];
    public List<BookmarkTag> BookmarkTags { get; set; } = [];
    
    public Category? Category { get; set; }

    public Bookmark(Guid id, string title, Url videoUrl, Url thumbnailUrl, string channel, string description)
    {
        Id = id;
        Title = title;
        VideoUrl = videoUrl;
        ThumbnailUrl = thumbnailUrl;
        Channel = channel;
        Description = description;
    }
    
    public Bookmark(string title, Url videoUrl, Url thumbnailUrl, string channel, string description)
    {
        Title = title;
        VideoUrl = videoUrl;
        ThumbnailUrl = thumbnailUrl;
        Channel = channel;
        Description = description;
    }
}