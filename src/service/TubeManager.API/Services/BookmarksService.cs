using TubeManager.Core.DTO;
using TubeManager.API.Entities;

namespace TubeManager.API.Services;

public class BookmarksService
{
    private static List<Bookmark> _bookmarks = new List<Bookmark>();

    public BookmarksService() { }
    
    public IEnumerable<Bookmark> Get()
    {
        return _bookmarks;
    }

    public Bookmark? Get(Guid id)
    {
        return _bookmarks.SingleOrDefault(b => b.Id == id);
    }
    
    public Guid? Create(BookmarkDTO b)
    {
        var exists = _bookmarks
            .Any(bookmark => b.VideoUrl == bookmark.VideoUrl);

        if (!exists)
        {
            return null;
        }

        var bookmark = new Bookmark(b.Title, b.VideoUrl, b.ThumbnailUrl, b.Channel, b.Description);
        _bookmarks.Add(bookmark);
        return bookmark.Id;
    }

    public bool Update(BookmarkDTO b)
    {
        var existing = _bookmarks.SingleOrDefault(bo => bo.Id == b.Id);

        if (existing is not null)
        {
            existing.Title = b.Title;
            existing.ThumbnailUrl = b.ThumbnailUrl;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Delete(Guid id)
    {
        var existing = _bookmarks.SingleOrDefault(b => b.Id == id);

        if (existing is not null)
        {
            _bookmarks.Remove(existing);
            return true;
        }
        else
        {
            return false;
        }
    }
}
