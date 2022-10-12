namespace KW.Api.Configurations;

internal static class Startup
{
    internal static ConfigureHostBuilder AddConfiguration(this ConfigureHostBuilder host)
    {
        host.ConfigureAppConfiguration((context, config) =>
        {
            const string configurationDirectory = "Configurations";
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{configurationDirectory}/hangfire.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        });

        return host;
    }
}
