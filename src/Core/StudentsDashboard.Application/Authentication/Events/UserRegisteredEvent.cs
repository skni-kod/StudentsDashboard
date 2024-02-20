using MediatR;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.Authentication.Events;

public record UserRegisteredEvent(User RegisteredUser) : INotification;