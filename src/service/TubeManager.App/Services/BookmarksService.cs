using TubeManager.App.Commands;
using TubeManager.App.Repositories;
using TubeManager.App.Abstractions;
using TubeManager.Core.DTO;
using TubeManager.Core.Entities;
using TubeManager.Core.Mappers;


namespace TubeManager.App.Services;

public class BookmarksService : IBookmarksService
{
    private readonly IBookmarkRepository _bookmarksRepository;
    private readonly ITagsRepository _tagsRepository;

    public BookmarksService(IBookmarkRepository bookmarkRepository, ITagsRepository tagsRepository)
    {
        _bookmarksRepository = bookmarkRepository;
        _tagsRepository = tagsRepository;
    }
    
    public IEnumerable<BookmarkDTO> Get(int page, int pageSize)
    {
        var dto = _bookmarksRepository
            .GetAll()
            .Skip((page-1)*pageSize)
            .Take(pageSize)
            .Select(b => new BookmarkDTO
        {
            Id = b.Id,
            Title = b.Title,
            VideoUrl = b.VideoUrl,
            ThumbnailUrl = b.ThumbnailUrl,
            Channel = b.Channel,
            Description = b.Description,
            Tags = Mappers.ToArray(b.Tags)
        });
        return dto;
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
                Description = b.Description,
                Tags = Mappers.ToArray(b.Tags)
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
            _bookmarksRepository.Update(existing);
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool Update(UpdateTagsForBookmark command)
    {
        var existing = _bookmarksRepository.Get(command.Id);

        if (existing is not null)
        {
            foreach (var tag in command.Tags)
            {
                existing.Tags.Add(_tagsRepository.Get(tag));
                _bookmarksRepository.Update(existing);
            }
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

    public int GetElementsCount()
    {
        return _bookmarksRepository.Count();
    }
}
