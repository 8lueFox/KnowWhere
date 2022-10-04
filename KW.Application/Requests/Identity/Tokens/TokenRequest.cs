using FluentValidation;

namespace KW.Application.Requests.Identity.Tokens;

public record TokenRequest(string Email, string Password);

public class TokenRequestValidator : AbstractValidator<TokenRequest>
{
    public TokenRequestValidator()
    {
        RuleFor(p => p.Email).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress()
                .WithMessage("Invalid Email Address");

        RuleFor(p => p.Password)
            .NotEmpty();
    }
}