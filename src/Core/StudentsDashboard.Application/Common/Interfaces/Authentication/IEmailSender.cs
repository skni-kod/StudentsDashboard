using StudentsDashboard.Application.Common.Models;

namespace StudentsDashboard.Application.Common.Interfaces.Authentication;

public interface IEmailSender
{
    bool Send(EmailMessage email);
}