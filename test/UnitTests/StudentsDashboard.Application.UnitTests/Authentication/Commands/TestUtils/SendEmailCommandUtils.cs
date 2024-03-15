using StudentsDashboard.Application.Authentication.Commands.SendEmail;
using StudentsDashboard.Application.UnitTests.TestUtils.Constants;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.UnitTests.Authentication.Commands.TestUtils;

public static class SendEmailCommandUtils
{
    public static SendEmailCommand SendEmailCommand() =>
        new SendEmailCommand(
            Constants.SendEmail.User
        );
}