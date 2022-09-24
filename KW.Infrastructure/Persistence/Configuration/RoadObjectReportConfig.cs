using KW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KW.Infrastructure.Persistence.Configuration;

public class RoadObjectReportConfig : IEntityTypeConfiguration<RoadObjectReport>
{
    public void Configure(EntityTypeBuilder<RoadObjectReport> builder)
    {
        builder
            .OwnsOne(p => p.Localization);
    }
}
