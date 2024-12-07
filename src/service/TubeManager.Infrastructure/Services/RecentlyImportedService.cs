using System.Threading.Channels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TubeManager.Infrastructure.Services;

internal sealed class RecentlyImportedService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceProviders;
    private readonly ChannelReader<string> _channel;

    public RecentlyImportedService(IServiceScopeFactory serviceProviders,
        ChannelReader<string> channel)
    {
        _serviceProviders = serviceProviders;
        _channel = channel;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var item in _channel.ReadAllAsync(stoppingToken))
        {
            DoIt(item.ToString());
        }
    }

    private void DoIt(string item)
    {
        
    }
}