using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TubeManager.App.Repositories;
using TubeManager.Infrastructure.Repositories;

namespace TubeManager.Infrastructure.DataAccessLayer;

internal static class Extensions
{
    public static IServiceCollection AddSqlite(this IServiceCollection services)
    {
        const string connString = "Data Source=../../infrastructure/db;";
        services.AddDbContext<BookmarksDbContext>(x => x.UseSqlite(connString));
        services.AddScoped<IBookmarkRepository, SqliteBookmarkRepository>();
        return services;
    }
}