using TubeManager.App.Commands;
using TubeManager.App.Repositories;
using TubeManager.App.Abstractions;
using TubeManager.App.Commands.Bookmarks;
using TubeManager.Core.DTO;
using TubeManager.Core.Entities;
using TubeManager.Core.Mappers;

namespace TubeManager.App.Services;

public class BookmarksService : IBookmarksService
{
    private readonly IBookmarkRepository _bookmarksRepository;
    private readonly ITagsRepository _tagsRepository;
    private readonly ICategoryRepository _categoryRepository;

    public BookmarksService(IBookmarkRepository bookmarkRepository, ITagsRepository tagsRepository, ICategoryRepository categoryRepository)
    {
        _bookmarksRepository = bookmarkRepository;
        _tagsRepository = tagsRepository;
        _categoryRepository = categoryRepository;
    }
    
    public IEnumerable<BookmarkDTO> Get(int page, int pageSize)
    {
        var dto = _bookmarksRepository
            .GetAll()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(b =>
            {
                if (b.Category is null)
                {
                    return new BookmarkDTO
                    {
                        Id = b.Id,
                        Title = b.Title,
                        VideoUrl = b.VideoUrl,
                        ThumbnailUrl = b.ThumbnailUrl,
                        Channel = b.Channel,
                        Description = b.Description,
                        Tags = Mappers.ToArray(b.Tags),
                        Category = null
                    };
                }
                else
                {
                    return new BookmarkDTO
                    {
                        Id = b.Id,
                        Title = b.Title,
                        VideoUrl = b.VideoUrl,
                        ThumbnailUrl = b.ThumbnailUrl,
                        Channel = b.Channel,
                        Description = b.Description,
                        Tags = Mappers.ToArray(b.Tags),
                        Category = new CategoryDTO(b.Category.Id, b.Category.Name, b.Category.Description)
                    };
                }
            });
        return dto;
    }

    public IEnumerable<BookmarkDTO> Get()
    {
        return _bookmarksRepository
            .GetAll()
            .Select(b =>
            {
                if (b.Category is null)
                {
                    return new BookmarkDTO
                    {
                        Id = b.Id,
                        Title = b.Title,
                        VideoUrl = b.VideoUrl,
                        ThumbnailUrl = b.ThumbnailUrl,
                        Channel = b.Channel,
                        Description = b.Description,
                        Tags = Mappers.ToArray(b.Tags),
                        Category = null
                    };
                }
                else
                {
                    return new BookmarkDTO
                    {
                        Id = b.Id,
                        Title = b.Title,
                        VideoUrl = b.VideoUrl,
                        ThumbnailUrl = b.ThumbnailUrl,
                        Channel = b.Channel,
                        Description = b.Description,
                        Tags = Mappers.ToArray(b.Tags),
                        Category = new CategoryDTO(b.Category.Id, b.Category.Name, b.Category.Description)
                    };
                }

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

    public bool Update(DeleteTagFromBookmark command)
    {
        var existing = _bookmarksRepository.Get(command.BookmarkId);
        if (existing is not null)
        {
            // var tagsId = existing.Tags.Select(t => t.Id); 
            // var tagsToDelete = tagsId.Intersect(command.TagsId);
            foreach (var tagId in command.TagsId)
            {
                var toDelete = existing.Tags.SingleOrDefault(t => t.Id == tagId );
                existing.Tags.Remove(toDelete);
            }
            // List<Tag> updatedTags = [];
            // foreach (var tagIdToDelete in command.TagsId)
            // {
            //     updatedTags.Add(existing.Tags.SingleOrDefault(t => t.Id == tagIdToDelete));
            // }
            //
            // existing.Tags = updatedTags;

                _bookmarksRepository.Update(existing);
                return true;

        }
        return false;
    }

    public bool Update(AddCategory command)
    {
        var bookmark = _bookmarksRepository.Get(command.bookmarkId);
        var category = _categoryRepository.Get(command.categoryId);

        if ((bookmark is null) || (category is null))
        {
            return false;
        }
        
        bookmark.Category = category;
        _bookmarksRepository.Update(bookmark);
        return true;
    }
}
