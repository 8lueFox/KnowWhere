using KW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KW.Infrastructure.Persistence.Configuration;

public class RoadObjectConfig : IEntityTypeConfiguration<RoadObject>
{
    public void Configure(EntityTypeBuilder<RoadObject> builder)
    {
        builder.
            Property(b => b.Name)
                .HasMaxLength(256);

        builder
            .OwnsOne(b => b.Colour);
    }
}
