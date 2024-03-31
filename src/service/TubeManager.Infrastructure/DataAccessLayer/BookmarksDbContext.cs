using Microsoft.EntityFrameworkCore;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer;

internal sealed class BookmarksDbContext : DbContext
{
    public DbSet<Bookmark> Bookmarks { get; set; }

    public BookmarksDbContext(DbContextOptions<BookmarksDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
