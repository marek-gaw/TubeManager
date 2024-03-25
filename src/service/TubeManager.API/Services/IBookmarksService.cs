using TubeManager.API.Commands;
using TubeManager.API.DTO;

namespace TubeManager.API.Services;

public interface IBookmarksService
{
    IEnumerable<BookmarkDTO> Get();
    BookmarkDTO? Get(Guid id);
    Guid? Create(CreateBookmark command);
    bool Update(UpdateBookmark command);
    bool Delete(DeleteBookmark command);
}