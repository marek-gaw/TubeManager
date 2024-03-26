using TubeManager.Core.Entities;

namespace TubeManager.App.Repositories;

public interface IBookmarkRepository
{
    IEnumerable<Bookmark> GetAll();
    Bookmark Get(Guid id);
    Bookmark Get(string videoUrl);
    void Add(Bookmark bookmark);
    void Update(Bookmark bookmark);
    void Delete(Bookmark bookmark);
}
