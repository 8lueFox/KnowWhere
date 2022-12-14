using KW.Shared.MailingServiceModels;

namespace KW.MailingService.Application;

public interface IMailService
{
    Task SendAsync(MailRequest request, CancellationToken ct);
    Task SendAsync(RegistrationMailRequest request, CancellationToken ct);
}
