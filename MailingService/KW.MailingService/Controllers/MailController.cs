using KW.MailingService.Application;
using KW.Shared.MailingServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KW.MailingService.Api.Controllers;

[Route("api/[controller]/[action]")]
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

    [HttpPost(Name = "SendRegistarionMail")]
    public async Task<ActionResult<string>> SendRegistrationMail([FromBody] RegistrationMailRequest request)
    {
        await _mailService.SendAsync(request, new CancellationToken());

        return Ok("Sended");
    }
}
