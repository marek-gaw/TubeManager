using TubeManager.App.Commands.Tags;
using TubeManager.Core.DTO;

namespace TubeManager.App.Abstractions;

public interface ITagsService
{
    IEnumerable<TagDTO> Get();
    TagDTO? Get(Guid id);
    Guid? Create(CreateTag command);
    bool Update(UpdateTag command);
    bool Delete(DeleteTag command);
}