using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Authentication.Events;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Contracts.Authentication;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMediator _mediator;

    public RegisterCommandHandler(IUserRepository userRepository, IMediator mediator)
    {
        _userRepository = userRepository;
        _mediator = mediator;
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
        
        var id = _userRepository.Add(user);

        _mediator.Publish(new UserRegisteredEvent(user));

        return new RegisterResponse(id);
    }
}