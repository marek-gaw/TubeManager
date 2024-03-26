using TubeManager.App.Commands;
using TubeManager.Core.DTO;

namespace TubeManager.App.Abstractions;

public interface IBookmarksService
{
    IEnumerable<BookmarkDTO> Get();
    BookmarkDTO? Get(Guid id);
    Guid? Create(CreateBookmark command);
    bool Update(UpdateBookmark command);
    bool Delete(DeleteBookmark command);
}