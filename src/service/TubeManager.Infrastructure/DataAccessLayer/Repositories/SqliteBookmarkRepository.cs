using Microsoft.EntityFrameworkCore;
using TubeManager.App.Repositories;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer.Repositories;

internal sealed class SqliteBookmarkRepository : IBookmarkRepository
{
    private readonly BookmarksDbContext _dbContext;
    private readonly DbSet<Bookmark> _bookmarks;

    public SqliteBookmarkRepository(BookmarksDbContext dbContext)
    {
        _dbContext = dbContext;
        _bookmarks = _dbContext.Bookmarks;
    }

    public IEnumerable<Bookmark> GetAll() => _bookmarks
        .Include("Tags")
        .Include("Category")
        .ToList();
    public Bookmark Get(Guid id)
    {
        return _bookmarks
            .Where(b => b.Id == id)
            .Include("Tags")
            .Include("Category")
            .SingleOrDefault();
    }

    public IEnumerable<Bookmark> GetByQuery(string query)
    {
        var ret =  _bookmarks
            .Where(b => EF.Functions.Like(b.Title, $"%{query}%"))
            .ToList();
        return ret;
    }

    public Bookmark Get(string videoUrl) => _bookmarks
        .Where(b => b.VideoUrl == videoUrl)
        .SingleOrDefault();

    public void Add(Bookmark bookmark)
    {
        _bookmarks.Add(bookmark);
        _dbContext.SaveChanges();
    }

    public void Update(Bookmark bookmark)
    {
        _bookmarks.Update(bookmark);
        _dbContext.SaveChanges();
    }

    public void Delete(Bookmark bookmark)
    {
        _bookmarks.Remove(bookmark);
        _dbContext.SaveChanges();
    }

    public int Count()
    {
        return _bookmarks.Count();
    }
}