using TubeManager.API.Commands;
using TubeManager.API.DTO;
using TubeManager.API.Entities;
using TubeManager.API.Repositories;

namespace TubeManager.API.Services;

public class BookmarksService : IBookmarksService
{
    private readonly IBookmarkRepository _bookmarksRepository;

    public BookmarksService(IBookmarkRepository repository)
    {
        _bookmarksRepository = repository;
    }
    
    public IEnumerable<BookmarkDTO> Get()
    {
        return _bookmarksRepository
            .GetAll()
            .Select(b => new BookmarkDTO
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
        var existing = _bookmarksRepository.Get(command.VideoUrl);

        if (existing is null)
        {
            return null;
        }

        var bookmark = new Bookmark(command.BookmarkId, command.Title, command.VideoUrl, command.ThumbnailUrl, command.Channel, command.Description);
        _bookmarksRepository.Add(bookmark);
        return bookmark.Id;
    }

    public bool Update(UpdateBookmark command)
    {
        var existing = _bookmarksRepository.Get(command.Id);

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
        var existing = _bookmarksRepository.Get(command.id);

        if (existing is not null)
        {
            _bookmarksRepository.Delete(existing);
            return true;
        }
        else
        {
            return false;
        }
    }
}
