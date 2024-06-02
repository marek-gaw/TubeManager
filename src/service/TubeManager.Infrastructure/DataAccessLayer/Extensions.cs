using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TubeManager.App.Repositories;
using TubeManager.Infrastructure.DataAccessLayer.Repositories;

namespace TubeManager.Infrastructure.DataAccessLayer;

internal static class Extensions
{
    public static IServiceCollection AddSqlite(this IServiceCollection services)
    {
        const string connString = "Data Source=../../../infrastructure/tubemanager.db;";
        services.AddDbContext<BookmarksDbContext>(x => x.UseSqlite(connString));
        services.AddScoped<IBookmarkRepository, SqliteBookmarkRepository>();
        services.AddScoped<ITagsRepository, SqliteTagsRepository>();
        services.AddScoped<IChannelsRepository, SqliteChannelsRepository>();
        services.AddScoped<ICategoryRepository, SqliteCategoryRepository>();
        return services;
    }
}