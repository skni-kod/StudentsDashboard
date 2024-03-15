﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using StudentsDashboard.Application.Common.Models;
using StudentsDashboard.Infrastructure.Authentication;

namespace StudentsDashboard.Infrastructure.Services;

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
        
    public void Send(EmailMessage request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_emailSettings.Host));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = request.Body
        };

        using var smtp = new SmtpClient();
        smtp.Connect(_emailSettings.ServerName, _emailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_emailSettings.Host, _emailSettings.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}