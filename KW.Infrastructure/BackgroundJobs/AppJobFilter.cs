using Hangfire.Client;
using Hangfire.Logging;
using KW.Infrastructure.Common;
using KW.Shared.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KW.Infrastructure.BackgroundJobs;

public class AppJobFilter : IClientFilter
{
    private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

    private readonly IServiceProvider _servcies;

    public AppJobFilter(IServiceProvider servcies) => _servcies = servcies;

    public void OnCreating(CreatingContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        Logger.InfoFormat("Set UserId parameters to job {0}...", context.Job.Method.Name);

        using var scope = _servcies.CreateScope();

        var httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
        _ = httpContext ?? throw new InvalidOperationException("Can't create a job without HttpContext");

        string? userId = httpContext.User.GetUserId();
        context.SetJobParameter(QueryStringKeys.UserId, userId);
    }

    public void OnCreated(CreatedContext filterContext) =>
        Logger.InfoFormat(
            "Job created with parameters {0}",
            filterContext.Parameters.Select(x => x.Key + "=" + x.Value).Aggregate((s1, s2) => s1 + s2));
}
