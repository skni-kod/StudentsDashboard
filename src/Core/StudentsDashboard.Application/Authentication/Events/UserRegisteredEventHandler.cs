using MediatR;
using StudentsDashboard.Application.Authentication.Commands.SendEmail;

namespace StudentsDashboard.Application.Authentication.Events;

public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
{
    private readonly IMediator _mediator;

    public UserRegisteredEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task Handle(UserRegisteredEvent @event, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SendEmailCommand(@event.RegisteredUser));
    }
}