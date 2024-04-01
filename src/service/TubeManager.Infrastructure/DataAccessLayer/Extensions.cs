using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TubeManager.App.Repositories;
using TubeManager.Infrastructure.DataAccessLayer.Repositories;

namespace TubeManager.Infrastructure.DataAccessLayer;

internal static class Extensions
{
    public static IServiceCollection AddSqlite(this IServiceCollection services)
    {
        const string connString = "Data Source=../../../../../../tubemanager.db;";
        services.AddDbContext<BookmarksDbContext>(x => x.UseSqlite(connString));
        services.AddScoped<IBookmarkRepository, SqliteBookmarkRepository>();
        return services;
    }

    //TODO: inject connection string from the runtime, when Background Service starts.
    public static IServiceCollection AddExternalSqlite(this IServiceCollection services)
    {
        services.AddDbContext<ImportedDbContext>();
        return services;
    }
}