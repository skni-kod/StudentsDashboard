using FluentValidation;

namespace StudentsDashboard.Application.Authentication.Commands.VerifyEmail;

public class VerifyEmailCommandValidator : AbstractValidator<VerifyEmailCommand>
{
    public VerifyEmailCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Token is required")
            .Length(6).WithMessage("Token must be 6 characters long");
    }
}