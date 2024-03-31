using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TubeManager.Core.Entities;
using TubeManager.Core.ValueObjects;

namespace TubeManager.Infrastructure.DataAccessLayer.Configurations;

internal sealed class BookmarksConfiguration : IEntityTypeConfiguration<Bookmark>
{
    public void Configure(EntityTypeBuilder<Bookmark> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.VideoUrl)
            .HasConversion(x => x.Value, x => new Url(x));
        builder.Property(x => x.ThumbnailUrl)
            .HasConversion(x => x.Value, x => new Url(x));
    }
}