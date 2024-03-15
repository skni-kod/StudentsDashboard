using MediatR;
using ErrorOr;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Contracts.Authentication;
using StudentsDashboard.Application.Persistance;

namespace StudentsDashboard.Application.Authentication.Commands.VerifyEmail;

public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, ErrorOr<VerifyEmailResponse>>
{
    private readonly IUserRepository _userRepository;

    public VerifyEmailCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<VerifyEmailResponse>> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetUserByEmail(request.Email);

        if (user is null)
        {
            return Errors.User.UserDoesNotExist;
        }

        if (user.VerifiedAt is not null)
        {
            return Errors.User.VerifiedEmail;
        }

        if (user.VerificationToken != request.Token)
        {
            return Errors.User.InvalidToken;
        }

        _userRepository.VerifyEmail(user);

        return new VerifyEmailResponse("The email has been successfully verified");
    }
}