using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Contracts.Authentication;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResponse>>
{
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var isExist = _userRepository.Any(request.Email);
        if (isExist)
        {
            return Errors.User.DuplicateEmail;
        }
        
        var user = new User
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password
        };
        
        _userRepository.Add(user);

        return new RegisterResponse("Registration completed");
    }
}