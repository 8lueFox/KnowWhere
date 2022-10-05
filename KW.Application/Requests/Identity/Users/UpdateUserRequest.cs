namespace KW.Application.Requests.Identity.Users;

public record UpdateUserRequest(string? Id, string? FirstName, string? LastName, string? Email, string? PhoneNumber);