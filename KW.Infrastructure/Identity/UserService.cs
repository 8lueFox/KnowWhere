using KW.Application.Common.Exceptions;
using KW.Application.Common.Interfaces;
using KW.Application.Requests.Identity.Users;
using KW.Shared.Authorization;
using KW.Shared.MailingServiceModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace KW.Infrastructure.Identity;

public partial class UserService : IUserService
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

        await _userManager.AddToRoleAsync(user, AppRoles.Basic);

        var messages = new List<string> { string.Format("User {0} Registred.", user.UserName)};

        string emailVerificationUri = await GetEmailVerificationUriAsync(user, origin);

        var emailModel = new RegistrationMailRequest
        {
            MailRequest = new(new List<string> { user.Email }, "KnowWhere - confirm your registration"),
            Model = new RegistrationModel
            {
                Email = user.Email,
                Username = user.UserName,
                Url = emailVerificationUri
            }
        };

        var json = JsonConvert.SerializeObject(emailModel);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var url = "https://localhost:9001/api/Mail/SendRegistrationMail";

        using var client = new HttpClient();
        await client.PostAsync(url, data);
        messages.Add("Email sended.");

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
