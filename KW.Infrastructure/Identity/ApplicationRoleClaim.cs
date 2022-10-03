using Microsoft.AspNetCore.Identity;

namespace KW.Infrastructure.Identity;

public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }
}
