using Microsoft.EntityFrameworkCore;

namespace KW.Infrastructure.Persistence.Context;

public abstract class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options)
        :base(options)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}