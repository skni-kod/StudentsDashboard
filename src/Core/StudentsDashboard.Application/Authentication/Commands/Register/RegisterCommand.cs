using MediatR;
using ErrorOr;
using StudentsDashboard.Application.Contracts.Authentication;

namespace StudentsDashboard.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword) : IRequest<ErrorOr<RegisterResponse>>;