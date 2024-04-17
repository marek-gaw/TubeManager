using TubeManager.App.Repositories;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.Repositories;

public class InMemoryBookmarkRepository : IBookmarkRepository
{
    private readonly List<Bookmark> _bookmarks;

    public InMemoryBookmarkRepository()
    {
        _bookmarks = new List<Bookmark>
        {
            new(
                Guid.NewGuid(),
                "100 COMMITÓW | KONKURS DLA KAŻDEGO PROGRAMISTY/STKI!",
                "https://www.youtube.com/watch?v=GADbUCHBnN8",
                "",
                "DevMentors",
                "Lorem ipsum dolor met"
            )
        };
    }
    
    public IEnumerable<Bookmark> GetAll()
    {
        return _bookmarks;
    }

    public Bookmark Get(Guid id)
    {
        return _bookmarks.SingleOrDefault(x => x.Id == id);
    }

    public Bookmark Get(string videoUrl)
    {
        return _bookmarks.SingleOrDefault(x => x.VideoUrl == videoUrl);
    }

    public void Add(Bookmark bookmark)
    {
        _bookmarks.Add(bookmark);
    }

    public void Update(Bookmark bookmark)
    {
    }

    public void Delete(Bookmark bookmark)
    {
    }

    public int Count()
    {
        return _bookmarks.Count();
    }
}