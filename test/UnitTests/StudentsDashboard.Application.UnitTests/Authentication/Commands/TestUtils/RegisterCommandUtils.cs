using StudentsDashboard.Application.Authentication.Commands.Register;
using StudentsDashboard.Application.UnitTests.TestUtils.Constants;

namespace StudentsDashboard.Application.UnitTests.Authentication.Commands.TestUtils;

public static class RegisterCommandUtils
{
    public static RegisterCommand RegisterCommand() =>
        new RegisterCommand(
            Constants.Register.FirstName,
            Constants.Register.LastName,
            Constants.Register.Email,
            Constants.Register.Password,
            Constants.Register.ConfirmPassword
        );
}