using ErrorOr;

namespace StudentsDashboard.Application.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =>
            Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already taken");

        public static Error BadData => 
            Error.Conflict(
                code:"User.BadData", 
                description: "Wrong login data");
    }
}