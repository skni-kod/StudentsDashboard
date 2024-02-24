using System.Text;
using MediatR;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using StudentsDashboard.Application.Common.Models;
using StudentsDashboard.Application.Persistance;

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
            Body = CreateVerifyEmailMessage(request.RegisteredUser.VerificationToken),
        };
        
        _emailSender.Send(email);
        
        return Task.FromResult(Unit.Value);
    }

    private string CreateVerifyEmailMessage(string verificationToken)
    {
        var message = new StringBuilder();
        message.Append("<h1>Please verify your email</h1>");
        message.Append($"<h2>Your code: {verificationToken}");
        return message.ToString();
    }
}