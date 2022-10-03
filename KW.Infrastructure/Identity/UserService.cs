using KW.Application.Common.Exceptions;
using KW.Application.Common.Interfaces;
using KW.Application.Requests.Identity.Users;
using KW.Shared.Authorization;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KW.Infrastructure.Identity;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserDetailsDto> GetAsync(string userId, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new NotFoundException("User Not Found.");

        return user.Adapt<UserDetailsDto>();
    }

    public async Task<string> CreateAsync(CreateUserRequest request, string origin)
    {
        var user = new ApplicationUser
        {
            Email = request.Email, 
            FirstName = request.FirstName, 
            LastName = request.LastName, 
            UserName = request.UserName, 
            PhoneNumber = request.PhoneNumber, 
            IsActive = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new InternalServerException("Validation Errors Occured.", result.Errors.Select(x => x.Code + ": " + x.Description).ToList());
        }

        //await _userManager.AddToRoleAsync(user, AppRoles.Basic);

        var messages = new List<string> { string.Format("User {0} Registred.", user.UserName) };
        
        return string.Join(Environment.NewLine, messages);
    }

    public Task UpdateAsync(UpdateUserRequest request, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsWithEmailAsync(string email, string? exceptId = null)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsWithNameAsync(string name)
    {
        return await _userManager.FindByNameAsync(name) is not null;
    }
}
