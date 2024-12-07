using TubeManager.Core.Entities;

namespace TubeManager.App.Repositories;

public interface IRecentlyImportedRepository
{
    IEnumerable<RecentlyImported> GetAll();
    RecentlyImported Get(int id);
    RecentlyImported Add(RecentlyImported recentlyImported);
    RecentlyImported Update(RecentlyImported recentlyImported);
    RecentlyImported Delete(int id);
}