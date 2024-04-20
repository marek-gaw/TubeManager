using Microsoft.Extensions.DependencyInjection;
using TubeManager.App.Abstractions;
using TubeManager.App.Services;

namespace TubeManager.App;

public static class Extensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.AddScoped<IImportBackupService, ImportBackupService>();
        services.AddScoped<IBookmarksService, BookmarksService>();
        services.AddScoped<IFileService, FileService>();
        return services;
    }
}
