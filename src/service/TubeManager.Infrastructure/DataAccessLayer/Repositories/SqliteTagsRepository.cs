using Microsoft.EntityFrameworkCore;
using TubeManager.App.Repositories;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer.Repositories;

internal sealed class SqliteTagsRepository: ITagsRepository
{
    private readonly BookmarksDbContext _dbContext;
    private readonly DbSet<Tag> _tags;

    public SqliteTagsRepository(BookmarksDbContext dbContext)
    {
        _dbContext = dbContext;
        _tags = _dbContext.Tags;
    }

    public IEnumerable<Tag> GetAll() => _tags.ToList();

    public Tag Get(Guid id)
    {
        return _tags.Where(t => t.Id == id).SingleOrDefault();
    }

    public Tag Get(string title)
    {
        return _tags.Where(t => t.Title == title).SingleOrDefault();
    }

    public void Add(Tag tag)
    {
        _tags.Add(tag);
        _dbContext.SaveChanges();
    }

    public void Update(Tag tag)
    {
        _tags.Update(tag);
        _dbContext.SaveChanges();
    }

    public void Delete(Tag tag)
    {
        _tags.Remove(tag);
        _dbContext.SaveChanges();
    }
}