using KW.Application.Common.Interfaces;
using KW.Application.Requests.Identity.Users;
using Microsoft.AspNetCore.Mvc;

namespace KW.Api.Controllers.Identity;

public class UsersController : BaseApiController
{
    public readonly IUserService _userService;

    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet("{id}")]
    public Task<UserDetailsDto> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        return _userService.GetAsync(id, cancellationToken);
    }

    [HttpPost]
    public Task<string> CreateAsync(CreateUserRequest request)
    {
        return _userService.CreateAsync(request, GetOriginFromRequest());
    }

    [HttpGet("confirm-email")]
    public async Task<string> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code, CancellationToken ct)
    {
        return await _userService.ConfirmEmailAsync(userId, code, ct);
    }

    private string GetOriginFromRequest() => $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";
}
