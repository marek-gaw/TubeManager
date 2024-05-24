using Microsoft.EntityFrameworkCore;
using TubeManager.App.Repositories;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer.Repositories;

internal sealed class SqliteCategoryRepository: ICategoryRepository
{
    private readonly BookmarksDbContext _dbContext;
    private readonly DbSet<Category> _category;

    public SqliteCategoryRepository(BookmarksDbContext context)
    {
        _dbContext = context;
        _category = _dbContext.Categories;
    }
    
    public IEnumerable<Category> GetAll()
    {
        return _category.ToList();
    }

    public Category Get(Guid id)
    {
        return _category.Where(c => c.Id == id).SingleOrDefault();
    }

    public Category Get(string name)
    {
        return _category.Where(c => c.Name == name).SingleOrDefault();
    }

    public void Add(Category category)
    {
        _category.Add(category);
        _dbContext.SaveChanges();
    }

    public void Update(Category category)
    {
        _category.Update(category);
        _dbContext.SaveChanges();
    }

    public void Delete(Category category)
    {
        _category.Remove(category);
        _dbContext.SaveChanges();
    }
}