using ErrorOr;

namespace StudentsDashboard.Application.Common.Errors;

public static class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =>
            Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already taken");
    }
}