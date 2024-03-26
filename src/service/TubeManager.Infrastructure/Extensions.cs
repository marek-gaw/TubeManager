using Microsoft.Extensions.DependencyInjection;
using TubeManager.Infrastructure.Repositories;
using TubeManager.App.Repositories;

namespace TubeManager.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IBookmarkRepository, InMemoryBookmarkRepository>();
        return services;
    }
}