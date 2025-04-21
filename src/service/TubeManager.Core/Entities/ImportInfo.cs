namespace TubeManager.Core.Entities;

public sealed class ImportInfo
{
    public Guid Id { get; set; }
    public DateTime ImportTimestamp { get; set; }
    public Guid BookmarkId { get; set; }
    
    public ImportInfo(Guid id, DateTime importTimestamp, Guid bookmarkId)
    {
        Id = id;
        ImportTimestamp = importTimestamp;
        BookmarkId = bookmarkId;
    }
}