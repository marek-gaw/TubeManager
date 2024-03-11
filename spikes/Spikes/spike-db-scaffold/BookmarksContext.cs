using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using spike_db_scaffold.Model;

namespace spike_db_scaffold;

public partial class BookmarksContext : DbContext
{
    public BookmarksContext()
    {
    }

    public BookmarksContext(DbContextOptions<BookmarksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=database/bookmarks.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.YouTubeVideoId);

            entity.Property(e => e.YouTubeVideoId).HasColumnName("YouTube_Video_Id");
            entity.Property(e => e.OrderIndex).HasColumnName("Order_Index");
            entity.Property(e => e.YouTubeVideo).HasColumnName("YouTube_Video");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
