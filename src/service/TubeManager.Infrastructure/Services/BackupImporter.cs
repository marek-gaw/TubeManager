using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TubeManager.Infrastructure.DataAccessLayer;

namespace TubeManager.Infrastructure.Services;

internal sealed class BackupImporter : IHostedService
{
    private readonly IServiceProvider _serviceProviders;

    public BackupImporter(IServiceProvider serviceProviders)
    {
        _serviceProviders = serviceProviders;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProviders.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ImportedDbContext>();
        
        //TODO: implement fetching data from the database
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}