using TubeManager.Core.Entities;

namespace TubeManager.App.Repositories;

public interface ITagsRepository
{
    IEnumerable<Tag> GetAll();
    Tag Get(Guid id);
    Tag Get(string title);
    void Add(Tag tag);
    void Update(Tag tag);
    void Delete(Guid id);
}