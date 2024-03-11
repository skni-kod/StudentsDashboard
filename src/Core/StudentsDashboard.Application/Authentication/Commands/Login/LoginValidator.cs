using FluentValidation;

namespace StudentsDashboard.Application.Authentication.Commands.Login;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Please provide correct details");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Please provide correct details");
    }
}