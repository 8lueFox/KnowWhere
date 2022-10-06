using KW.MailingService.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace KW.MailingService.Infrastructure;

public class SmtpMailService : IMailService
{
    private readonly MailSettings _settings;

    public SmtpMailService(IOptions<MailSettings> settings, IConfiguration config)
    {
        _settings = settings.Value;
    }

    public Task SendAsync(MailRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
