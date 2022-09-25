using KW.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KW.Infrastructure.Persistence.Context;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        if (_context.Database.IsSqlServer())
        {
            await _context.Database.MigrateAsync();
        }
    }

    public async Task SeedAsync()
    {
        await TrySeedAsync();
    }

    public async Task TrySeedAsync()
    {
        if (!_context.RoadObjects.Any())
        {
            _context.RoadObjects.Add(new RoadObject("Speed camera", "#FF5733"));
            _context.RoadObjects.Add(new RoadObject("Speed control", "#6666FF"));
            _context.RoadObjects.Add(new RoadObject("Undercover", "#999999"));
        }

        await _context.SaveChangesAsync();
    }
}
