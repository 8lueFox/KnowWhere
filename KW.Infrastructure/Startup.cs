using KW.Infrastructure.Auth;
using KW.Infrastructure.BackgroundJobs;
using KW.Infrastructure.Common;
using KW.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KW.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddAuth(config)
            .AddBackgroundJobs(config)
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddPersistence(config)
            .AddServices();
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
        builder
            .UseHangfireDashboard(config);
}
