using Microsoft.Extensions.DependencyInjection;
using TubeManager.Infrastructure.Repositories;
using TubeManager.App.Repositories;
using TubeManager.Infrastructure.DataAccessLayer;

namespace TubeManager.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSqlite();
        
        return services;
    }
}