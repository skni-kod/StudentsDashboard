using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class SendEmail
    {
        public static readonly User User = new User()
        {
            FirstName = "SendEmail FirstName",
            LastName = "SendEmail LastName",
            Email = "SendEmail@email.com",
            Password = "SendEmail Password"
        };
    }
}