using ErrorOr;
using MediatR;
using StudentsDashboard.Application.Contracts.Authentication;

namespace StudentsDashboard.Application.Authentication.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
    ) : IRequest<ErrorOr<LoginResponse>>;