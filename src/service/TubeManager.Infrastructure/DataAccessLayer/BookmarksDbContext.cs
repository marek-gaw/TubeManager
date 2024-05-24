using Microsoft.EntityFrameworkCore;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer;

internal sealed class BookmarksDbContext : DbContext
{
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Category> Categories { get; set; }

    public BookmarksDbContext(DbContextOptions<BookmarksDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Entity<Bookmark>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Bookmarks)
            .UsingEntity<BookmarkTag>();
        modelBuilder.Entity<Tag>()
            .HasMany(e => e.Bookmarks)
            .WithMany(e => e.Tags)
            .UsingEntity<BookmarkTag>();
    }
}
