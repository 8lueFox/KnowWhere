namespace KW.Application.Requests.Identity.Users;

public record CreateUserRequest(string? FirstName, string? LastName, string? Email, string? UserName,
    string? Password, string? ConfirmPassword, string? PhoneNumber);
