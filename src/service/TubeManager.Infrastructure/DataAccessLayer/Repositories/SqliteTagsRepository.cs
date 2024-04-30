using TubeManager.App.Repositories;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer.Repositories;

internal sealed class SqliteTagsRepository: ITagsRepository
{
    public IEnumerable<Tag> GetAll()
    {
        throw new NotImplementedException();
    }

    public Tag Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Tag Get(string title)
    {
        throw new NotImplementedException();
    }

    public void Add(Tag tag)
    {
        throw new NotImplementedException();
    }

    public void Update(Tag tag)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}