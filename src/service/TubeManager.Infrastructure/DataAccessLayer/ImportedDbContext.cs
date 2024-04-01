using Microsoft.EntityFrameworkCore;

namespace TubeManager.Infrastructure.DataAccessLayer;

internal sealed class ImportedDbContext: DbContext
{
    public ImportedDbContext(DbContextOptions<ImportedDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}