using System.Threading.Channels;
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
        services.AddSingleton<Channel<string>>(Channel.CreateUnbounded<string>(new UnboundedChannelOptions() { SingleReader = true }));
        services.AddSingleton<ChannelWriter<string>>(svc => svc.GetRequiredService<Channel<string>>().Writer);
        services.AddScoped<ITagsService, TagsService>();
        services.AddScoped<IChannelsService, ChannelsService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}
