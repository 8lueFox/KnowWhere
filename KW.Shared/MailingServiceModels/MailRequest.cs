namespace KW.Shared.MailingServiceModels;

public class MailRequest
{

    public List<string> To { get; set; }
    public string Subject { get; set; }
    public string? Body { get; set; }
    public string? From { get; set; }
    public string? DisplayName { get; set; }
    public string? ReplyTo { get; set; }
    public string? ReplyToName { get; set; }
    public List<string> Bcc { get; set; }
    public List<string> Cc { get; set; }
    public IDictionary<string, byte[]> AttachmentData { get; set; }
    public IDictionary<string, string> Headers { get; set; }

    public MailRequest(List<string> to, string subject, string? body = "", string? from = "", string? displayName = "", string? replyTo = "", string? replyToName = "", List<string> bcc = null, List<string> cc = null, IDictionary<string, byte[]> attachmentData = null, IDictionary<string, string> headers = null)
    {
        To = to;
        Subject = subject;
        Body = body;
        From = from;
        DisplayName = displayName;
        ReplyTo = replyTo;
        ReplyToName = replyToName;
        Bcc = bcc != null ? bcc : new List<string>();
        Cc = cc != null ? cc : new List<string>();
        AttachmentData = attachmentData != null ? attachmentData : new Dictionary<string, byte[]>();
        Headers = headers != null ? headers : new Dictionary<string, string>();
    }
}