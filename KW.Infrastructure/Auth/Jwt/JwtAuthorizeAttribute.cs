using Microsoft.AspNetCore.Authorization;

namespace KW.Infrastructure.Auth.Jwt;

public class JwtAuthorizeAttribute : AuthorizeAttribute
{
    public JwtAuthorizeAttribute()
    {
        AuthenticationSchemes = "Bearer";
    }
}