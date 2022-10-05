using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KW.Infrastructure.Identity;
using KW.Infrastructure.Auth.Jwt;

namespace KW.Infrastructure.Auth;

internal static class Startup
{
    internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddIdentity()
            .AddJwtAuth(config);

        return services;
    }
}
