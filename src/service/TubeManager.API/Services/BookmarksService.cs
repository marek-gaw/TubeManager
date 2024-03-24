using TubeManager.API.Commands;
using TubeManager.API.DTO;
using TubeManager.API.Entities;

namespace TubeManager.API.Services;

public class BookmarksService
{
    private static List<Bookmark> _bookmarks = new List<Bookmark>();

    public BookmarksService()
    {
        _bookmarks.Add(
            new Bookmark(
                Guid.NewGuid(),
                "100 COMMITÓW | KONKURS DLA KAŻDEGO PROGRAMISTY/STKI!",
                "https://www.youtube.com/watch?v=GADbUCHBnN8",
                "",
                "DevMentors",
                "Lorem ipsum dolor met"
            )
        );
    }

   
    
    public IEnumerable<BookmarkDTO> Get()
    {
        return _bookmarks.Select(b => new BookmarkDTO
        {
            Id = b.Id,
            Title = b.Title,
            VideoUrl = b.VideoUrl,
            ThumbnailUrl = b.ThumbnailUrl,
            Channel = b.Channel,
            Description = b.Description
        });
    }

    public BookmarkDTO? Get(Guid id)
    {
        return Get().SingleOrDefault(b => b.Id == id);
    }
    
    public Guid? Create(CreateBookmark command)
    {
        var existing = _bookmarks.SingleOrDefault(b => command.VideoUrl == b.VideoUrl);

        if (existing is null)
        {
            return null;
        }

        var bookmark = new Bookmark(command.BookmarkId, command.Title, command.VideoUrl, command.ThumbnailUrl, command.Channel, command.Description);
        _bookmarks.Add(bookmark);
        return bookmark.Id;
    }

    public bool Update(UpdateBookmark command)
    {
        var existing = _bookmarks.SingleOrDefault(bo => bo.Id == command.Id);

        if (existing is not null)
        {
            existing.Title = command.Title;
            existing.ThumbnailUrl = command.ThumbnailUrl;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Delete(DeleteBookmark command)
    {
        var existing = _bookmarks.SingleOrDefault(b => b.Id == command.id);

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
