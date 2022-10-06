namespace KW.MailingService.Application;

public record MailRequest(List<string> To, string Subject, string? Body, string? From, string? DisplayName, string? ReplyTo, string? ReplyToName,
    List<string> Bcc, List<string> Cc, IDictionary<string, byte[]> AttachmentData, IDictionary<string, string> Headers);