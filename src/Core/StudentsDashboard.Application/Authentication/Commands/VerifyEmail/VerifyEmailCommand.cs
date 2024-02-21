using MediatR;
using ErrorOr;
using StudentsDashboard.Application.Contracts.Authentication;

namespace StudentsDashboard.Application.Authentication.Commands.VerifyEmail;

public record VerifyEmailCommand(
    string Email,
    string Token
    ) : IRequest<ErrorOr<VerifyEmailResponse>>;