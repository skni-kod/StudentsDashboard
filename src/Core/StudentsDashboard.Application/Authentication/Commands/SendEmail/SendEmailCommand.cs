using MediatR;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Authentication.Commands.SendEmail;

public record SendEmailCommand(User RegisteredUser) : IRequest<Unit>;