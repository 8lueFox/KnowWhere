using KW.Infrastructure.Auth;
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
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddPersistence(config)
            .AddServices();
    }
}
