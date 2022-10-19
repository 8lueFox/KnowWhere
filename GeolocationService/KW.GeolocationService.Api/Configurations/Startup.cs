using KW.GeolocationService.Infrastructure;

namespace KW.GeolocationService.Api.Configurations;

internal static class Startup
{
    internal static ConfigureHostBuilder AddConfiguration(this ConfigureHostBuilder host)
    {
        host.ConfigureAppConfiguration((config) =>
        {
            const string configurationDirectory = "Configurations";

            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{configurationDirectory}/graphhopper.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        });

        return host;
    }

    internal static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration config) =>
        services.Configure<HooperSettings>(config.GetSection(nameof(HooperSettings)));
}
