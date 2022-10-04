namespace KW.Application.Requests.Identity.Tokens;

public record RefreshTokenRequest(string Token, string RefreshToken);
