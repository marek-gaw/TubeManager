namespace TubeManager.Core.Entities;

public sealed class Tag
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<Bookmark> Bookmarks { get; } = [];
    public List<BookmarkTag> BookmarkTags { get; } = [];

    public Tag(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
}