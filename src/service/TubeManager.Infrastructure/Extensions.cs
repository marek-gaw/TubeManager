using System.Threading.Channels;
using Microsoft.Extensions.DependencyInjection;
using TubeManager.Infrastructure.DataAccessLayer;
using TubeManager.Infrastructure.Services;
using StackExchange.Redis;

namespace TubeManager.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPostgres();
        services.AddSingleton<ChannelReader<string>>(svc => svc.GetRequiredService<Channel<string>>().Reader);
        services.AddHostedService<BackupImporter>(); // TODO: create instance on API call

        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("http://localhost:6379"));
        
        return services;
    }
}