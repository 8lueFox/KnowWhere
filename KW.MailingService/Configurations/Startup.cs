using KW.MailingService.Infrastructure;

namespace KW.MailingService.Api.Configurations;

internal static class Startup
{
    internal static ConfigureHostBuilder AddConfiguration(this ConfigureHostBuilder host)
    {
        host.ConfigureAppConfiguration((config) =>
        {
            const string configurationDirectory = "Configurations";

            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{configurationDirectory}/mail.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        });

        return host;
    }

    internal static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration config) =>
        services.Configure<MailSettings>(config.GetSection(nameof(MailSettings)));
}
