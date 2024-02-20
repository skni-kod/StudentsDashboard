using MediatR;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using StudentsDashboard.Application.Common.Models;

namespace StudentsDashboard.Application.Authentication.Commands.SendEmail;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Unit>
{
    private readonly IEmailSender _emailSender;

    public SendEmailCommandHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }
    
    public Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var email = new EmailMessage()
        {
            To = request.RegisteredUser.Email,
            Subject = "Verify Email",
            Body = "Please confirm your email"
        };
        
        var response = _emailSender.Send(email);
        
        return Task.FromResult(Unit.Value);
    }
}