using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<AndroidMetadatum> AndroidMetadata { get; set; }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=database/bookmarks.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AndroidMetadatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("android_metadata");

            entity.Property(e => e.Locale).HasColumnName("locale");
        });

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
