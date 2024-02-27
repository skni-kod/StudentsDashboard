using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using StudentsDashboard.Application.Contracts.Authentication;
using StudentsDashboard.Application.Persistance;

namespace StudentsDashboard.Application.Authentication.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, ErrorOr<LoginResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public LoginHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public async Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Email, request.Password);

        if (user is null) return Errors.User.BadData;

         _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
         
        return new LoginResponse("Successfull!");
    }
}