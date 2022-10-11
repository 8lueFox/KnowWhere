using KW.Application.Common.Exceptions;
using KW.Infrastructure.Common;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace KW.Infrastructure.Identity;

public partial class UserService
{
    private async Task<string> GetEmailVerificationUriAsync(ApplicationUser user, string origin)
    {
        string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        const string route = "Users/confirm-email/";
        var endpointUrl = new Uri(string.Concat($"{origin}/", route));
        string verificationUrl = QueryHelpers.AddQueryString(endpointUrl.ToString(), QueryStringKeys.UserId, user.Id);
        verificationUrl = QueryHelpers.AddQueryString(verificationUrl, QueryStringKeys.Code, code);
        return verificationUrl;
    }

    public async Task<string> ConfirmEmailAsync(string userId, string code, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .Where(u => u.Id == userId && !u.EmailConfirmed)
            .FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new InternalServerException("An error occured while confirming E-Mail.");

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

        var result = await _userManager.ConfirmEmailAsync(user, code);

        return result.Succeeded
            ? $"Account Confirmed for E-Mail {user.Email}. You can now use the /api/tokens endpoints to generate JWT."
            : throw new InternalServerException($"An error occured while confirming {user.Email}");
    }

    public Task<string> ConfirmPhoneNumberAsync(string userId, string code)
    {
        return null;
    }
}
