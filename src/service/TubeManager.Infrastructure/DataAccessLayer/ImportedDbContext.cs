using Microsoft.EntityFrameworkCore;
using TubeManager.Infrastructure.Models;

namespace TubeManager.Infrastructure.DataAccessLayer;

internal sealed class ImportedDbContext: DbContext
{
    public DbSet<ScaffoldedBookmark> Bookmarks { get; set; }
    public ImportedDbContext(DbContextOptions<ImportedDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ScaffoldedBookmark>(entity =>
        {
            entity.HasKey(e => e.YouTubeVideoId);

            entity.Property(e => e.YouTubeVideoId).HasColumnName("YouTube_Video_Id");
            entity.Property(e => e.OrderIndex).HasColumnName("Order_Index");
            entity.Property(e => e.YouTubeVideo).HasColumnName("YouTube_Video");
        });
    }
}