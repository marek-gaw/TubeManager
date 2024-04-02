using System.Globalization;
using System.IO.Compression;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using TubeManager.Infrastructure.DataAccessLayer;
using TubeManager.Infrastructure.Models;

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
        //using var scope = _serviceProviders.CreateScope();
        //var dbContext = scope.ServiceProvider.GetRequiredService<ImportedDbContext>();
        //TODO: implement fetching data from the database
        // 1. Extract zip file to System Temp dir
        const string archivePath = "../../../skytube-2023-08-18-180651.skytube";
        DateTime df = DateTime.Now;
        string extractTo = Path.GetTempPath() + df.ToString("u", CultureInfo.CurrentCulture);
        ZipFile.ExtractToDirectory(archivePath, extractTo);
        
        // 2. Read data from bookmarks.db
        var contextOptions = new DbContextOptionsBuilder<ImportedDbContext>()
            .UseSqlite($@"DataSource={extractTo}/bookmarks.db")
            .Options;

        using (var context = new ImportedDbContext(contextOptions))
        {
            var bookmarks = context.Bookmarks.ToList();
        }
        // TODO: 3. Import data from channels.db
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}