using KW.MailingService.Application;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace KW.MailingService.Infrastructure;

public class SmtpMailService : IMailService
{
    private readonly MailSettings _settings;
    private readonly IEmailTemplateService _emailTemplateService;

    public SmtpMailService(IOptions<MailSettings> settings, IEmailTemplateService emailTemplateService)
    {
        _settings = settings.Value;
        _emailTemplateService = emailTemplateService;
    }

    public async Task SendAsync(MailRequest request, CancellationToken ct)
    {
        try
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(_settings.DisplayName, request.From ?? _settings.From));

            request.To.ForEach(to => email.To.Add(MailboxAddress.Parse(to)));

            if(!string.IsNullOrEmpty(request.ReplyTo))  
                email.ReplyTo.Add(new MailboxAddress(request.ReplyToName, request.ReplyTo));

            if (request.Bcc != null)
                request.Bcc.Where(bccValue => !string.IsNullOrEmpty(bccValue))
                    .ToList()
                    .ForEach(address => email.Bcc.Add(MailboxAddress.Parse(address.Trim())));

            if (request.Cc != null)
                request.Cc.Where(bccValue => !string.IsNullOrEmpty(bccValue))
                    .ToList()
                    .ForEach(address => email.Cc.Add(MailboxAddress.Parse(address.Trim())));

            if(request.Headers != null)
                foreach (var header in request.Headers)
                    email.Headers.Add(header.Key, header.Value);

            var builder = new BodyBuilder();
            email.Sender = new MailboxAddress(request.DisplayName ?? _settings.DisplayName, request.From ?? _settings.From);
            email.Subject = request.Subject;
            builder.HtmlBody = _emailTemplateService.GenerateEmailTemplate(request.Body, new { });

            if(request.AttachmentData != null)
                foreach(var attachmentData in request.AttachmentData)
                    builder.Attachments.Add(attachmentData.Key, attachmentData.Value);

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
            await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
            await smtp.SendAsync(email, ct);
            await smtp.DisconnectAsync(true, ct);
        }
        catch (Exception) { }
    }
}
