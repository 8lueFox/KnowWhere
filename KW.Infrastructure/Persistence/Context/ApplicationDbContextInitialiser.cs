using KW.Domain.Entities;
using KW.Infrastructure.Identity;
using KW.Shared.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KW.Infrastructure.Persistence.Context;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationDbContextInitializer(ApplicationDbContext context,
        RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task InitializeAsync()
    {
        if (_context.Database.IsSqlServer())
        {
            await _context.Database.MigrateAsync();
        }
    }

    public async Task SeedAsync()
    {
        await SeedRoleAsync();
        await SeedUsersAsync();
        await TrySeedAsync();
    }

    private async Task SeedRoleAsync()
    {
        foreach(string roleName in AppRoles.DefaultRoles)
        {
            if(await _roleManager.Roles.SingleOrDefaultAsync(r => r.Name == roleName)
                is not ApplicationRole role)
            {
                role = new ApplicationRole(roleName);
                var result = await _roleManager.CreateAsync(role);
            }

            var roles2 = await _roleManager.Roles.ToListAsync();

            if (roleName == AppRoles.Basic)
                await AssignPermissionsToRoleAsync(_context, AppPermissions.Basic, role);
            else if(roleName == AppRoles.Admin)
                await AssignPermissionsToRoleAsync(_context, AppPermissions.Admin, role);
        }

        var roles = await _roleManager.Roles.ToListAsync();
    }

    private async Task SeedUsersAsync()
    {
        var adminUser = new ApplicationUser
        {
            FirstName = "Kacper",
            LastName = "Jędrzejewski",
            Email = "admin@root.pl",
            UserName = "8lueFox",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            NormalizedEmail = "admin@root.pl".ToUpperInvariant(),
            NormalizedUserName = "8lueFox".ToUpperInvariant(),
            IsActive = true
        };

        var password = new PasswordHasher<ApplicationUser>();
        adminUser.PasswordHash = password.HashPassword(adminUser, "alaMaKota");
        await _userManager.CreateAsync(adminUser);

        var roles = _roleManager.Roles.ToList();
        var roles2 = _userManager.SupportsUserRole;
        var roles3 = _userManager.GetRolesAsync(adminUser);

        if (!await _userManager.IsInRoleAsync(adminUser, AppRoles.Admin))
            await _userManager.AddToRoleAsync(adminUser, AppRoles.Admin);

        var basicUser = new ApplicationUser
        {
            FirstName = "Jan",
            LastName = "Kowalski",
            Email = "jan@gmail.com",
            UserName = "Janek99",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            NormalizedEmail = "jan@gmail.com".ToUpperInvariant(),
            NormalizedUserName = "Janek99".ToUpperInvariant(),
            IsActive = true
        };

        basicUser.PasswordHash = password.HashPassword(basicUser, "alaMaKota");
        await _userManager.CreateAsync(basicUser);

        if (!await _userManager.IsInRoleAsync(basicUser, AppRoles.Basic))
            await _userManager.AddToRoleAsync(basicUser, AppRoles.Basic);
    }

    public async Task TrySeedAsync()
    {
        if (!_context.RoadObjects.Any())
        {
            _context.RoadObjects.Add(new RoadObject("Speed camera", "#FF5733"));
            _context.RoadObjects.Add(new RoadObject("Speed control", "#6666FF"));
            _context.RoadObjects.Add(new RoadObject("Undercover", "#999999"));
        }

        await _context.SaveChangesAsync();
    }

    private async Task AssignPermissionsToRoleAsync(ApplicationDbContext dbContext, IReadOnlyList<AppPermission> permissions, ApplicationRole role)
    {
        var currentClaims = await _roleManager.GetClaimsAsync(role);
        foreach (var permission in permissions)
        {
            if (!currentClaims.Any(c => c.Type == AppClaims.Permission && c.Value == permission.Name))
            {
                dbContext.RoleClaims.Add(new ApplicationRoleClaim
                {
                    RoleId = role.Id,
                    ClaimType = AppClaims.Permission,
                    ClaimValue = permission.Name,
                    CreatedBy = "ApplicationDbSeeder"
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
