using TubeManager.Core.Entities;

namespace TubeManager.App.Repositories;

public interface IImportInfoRepository
{
    IEnumerable<ImportInfo> GetAll();
    ImportInfo Get(int id);
    ImportInfo Add(ImportInfo recentlyImported);
    ImportInfo Update(ImportInfo recentlyImported);
    ImportInfo Delete(int id);
}