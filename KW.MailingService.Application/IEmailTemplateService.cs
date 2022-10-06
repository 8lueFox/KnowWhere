namespace KW.MailingService.Application;

public interface IEmailTemplateService
{
    string GenerateEmailTemplate<T>(string templateName, T mailTemplateModel);
}
