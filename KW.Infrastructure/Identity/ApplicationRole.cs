using Microsoft.AspNetCore.Identity;

namespace KW.Infrastructure.Identity;

public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }

    public ApplicationRole(string name, string? description = null)
    {
        Description = description;
        NormalizedName = name.ToUpperInvariant();
    }
}
