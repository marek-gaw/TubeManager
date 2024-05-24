using TubeManager.Core.Entities;

namespace TubeManager.App.Repositories;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAll();
    Category Get(Guid id);
    Category Get(string channelId);
    void Add(Category category);
    void Update(Category category);
    void Delete(Category category);
}
