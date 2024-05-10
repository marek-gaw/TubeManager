namespace TubeManager.Core.Entities;

public sealed class BookmarkTag
{
    public Guid BookmarkId { get; set; }
    public Guid TagId { get; set; }
    public Bookmark Bookmark { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
