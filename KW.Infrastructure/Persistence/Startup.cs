using KW.Application.Common.Persistance;
using KW.Domain.Common.Contracts;
using KW.Infrastructure.Persistence;
using KW.Infrastructure.Persistence.Context;
using KW.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KW.Infrastructure.Persistence;

internal static class Startup
{
    internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("KnowWhereDB"))
            .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Add Repositories
        services.AddScoped(typeof(IRepository<>), typeof(ApplicationDbRepository<>));

        foreach (var aggregateRootType in
            typeof(IAggregateRoot).Assembly.GetExportedTypes()
                .Where(t => typeof(IAggregateRoot).IsAssignableFrom(t) && t.IsClass)
                .ToList())
        {
            // Add ReadRepositories.
            services.AddScoped(typeof(IReadRepository<>).MakeGenericType(aggregateRootType), sp =>
                sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(aggregateRootType)));
        }

        return services;
    }
}