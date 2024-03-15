using StudentsDashboard.Application.Common.Models;

namespace StudentsDashboard.Application.Common.Interfaces.Authentication;

public interface IEmailSender
{
    void Send(EmailMessage email);
}