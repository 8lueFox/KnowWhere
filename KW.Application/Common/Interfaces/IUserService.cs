using KW.Application.Requests.Identity.Users;

namespace KW.Application.Common.Interfaces;

public interface IUserService : ITransientService
{
    Task<bool> ExistsWithNameAsync(string name);
    Task<bool> ExistsWithEmailAsync(string email, string? exceptId = null);

    Task<UserDetailsDto> GetAsync(string userId, CancellationToken cancellationToken);

    Task<string> CreateAsync(CreateUserRequest request, string origin);
    Task UpdateAsync(UpdateUserRequest request, string userId);

    Task<string> ConfirmEmailAsync(string userId, string code, CancellationToken cancellationToken);
    Task<string> ConfirmPhoneNumberAsync(string userId, string code);
}
