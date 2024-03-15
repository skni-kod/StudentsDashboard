using StudentsDashboard.Application.Authentication.Commands.Login;
using StudentsDashboard.Application.UnitTests.TestUtils.Constants;

namespace StudentsDashboard.Application.UnitTests.Authentication.Commands.TestUtils;

public static class LoginCommandUtils
{
    public static LoginCommand LoginCommand() =>
        new LoginCommand(
            Constants.Login.Email,
            Constants.Login.Password
            );
}