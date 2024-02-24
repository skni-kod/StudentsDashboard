using StudentsDashboard.Application.Authentication.Commands.VerifyEmail;
using StudentsDashboard.Application.UnitTests.TestUtils.Constants;

namespace StudentsDashboard.Application.UnitTests.Authentication.Commands.TestUtils;

public static class VerifyEmailCommandUtils
{
    public static VerifyEmailCommand VerifyEmailCommand =>
        new VerifyEmailCommand(
            Constants.VerifyEmail.Email,
            Constants.VerifyEmail.Token
        );
}