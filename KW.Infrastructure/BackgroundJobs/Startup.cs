using Hangfire;
using Hangfire.Console;
using Hangfire.Console.Extensions;
using Hangfire.MemoryStorage;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KW.Infrastructure.BackgroundJobs;

internal static class Startup
{
    internal static IServiceCollection AddBackgroundJobs(this IServiceCollection services, IConfiguration config)
    {
        services.AddHangfireServer(options => config.GetSection("HangfireSettings:Server").Bind(options));

        services.AddHangfireConsoleExtensions();

        services.AddHangfire((provider, config) => config
            .UseMemoryStorage()
            .UseFilter(new AppJobFilter(provider))
            .UseFilter(new LogJobFilter())
            .UseConsole());

        return services;
    }

    internal static IApplicationBuilder UseHangfireDashboard(this IApplicationBuilder app, IConfiguration config)
    {
        var dashboardOptions = config.GetSection("HangfireSettings:Dashboard").Get<DashboardOptions>();

        dashboardOptions.Authorization = new[]
        {
            new HangfireCustomBasicAuthenticationFilter
            {
                User = config.GetSection("HangfireSettings:Credentials:User").Value,
                Pass = config.GetSection("HangfireSettings:Credentials:Password").Value
            }
        };

        return app.UseHangfireDashboard(config["HangfireSettings:Route"], dashboardOptions);
    }
}
