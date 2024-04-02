using Microsoft.Extensions.DependencyInjection;
using TubeManager.Infrastructure.Repositories;
using TubeManager.App.Repositories;
using TubeManager.Infrastructure.DataAccessLayer;
using TubeManager.Infrastructure.Services;

namespace TubeManager.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSqlite(); //internal database
        services.AddHostedService<BackupImporter>(); // TODO: create instance on API call
        
        return services;
    }
}