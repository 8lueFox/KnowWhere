using KW.MailingService.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KW.MailingService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailController : ControllerBase
{
    private readonly IMailService _mailService;

    public MailController(IMailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> SendMail([FromBody] MailRequest request)
    {
        await _mailService.SendAsync(request, new CancellationToken());

        return Ok("Sended");
    }
}
