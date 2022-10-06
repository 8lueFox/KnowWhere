namespace KW.MailingService.Application;

public interface IMailService
{
    Task SendAsync(MailRequest request, CancellationToken ct);
}
