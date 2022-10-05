using KW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KW.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(DbContextOptions options)
        :base(options)
    {
    }

    public DbSet<RoadObject> RoadObjects => Set<RoadObject>();
    public DbSet<RoadObjectReport> RoadObjectReports => Set<RoadObjectReport>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}