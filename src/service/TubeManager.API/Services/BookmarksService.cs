using TubeManager.API.Models;

namespace TubeManager.API.Services;

public class BookmarksService
{
    private readonly List<Bookmark> _bookmarks = new();
    
    public IEnumerable<Bookmark> Get()
    {
        return _bookmarks;
    }

    public Bookmark? Get(Guid id)
    {
        return _bookmarks.SingleOrDefault(b => b.Id == id);
    }
    
    public Guid? Create(Bookmark b)
    {
        var exists = _bookmarks
            .Any(bookmark => b.VideoUrl == bookmark.VideoUrl);

        if (!exists)
        {
            return null;
        }
        
        _bookmarks.Add(b);
        return b.Id;
    }

    public bool Update(Bookmark b)
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
