using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TubeManager.Core.Entities;

namespace TubeManager.Infrastructure.DataAccessLayer.Configurations;

internal sealed class TagsConfiguration: IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title);
    }
}