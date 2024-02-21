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

        public static Error UserDoesNotExist =>
            Error.NotFound(
                code: "User.UserDoesNotExist",
                description: "User with this email doesn't exist");

        public static Error VerifiedEmail =>
            Error.Conflict(
                code: "User.VerifiedEmail",
                description: "The email has already been verified");
        public static Error InvalidToken =>
            Error.Validation(
                code: "User.InvalidToken",
                description: "The token provided is invalid");
    }
}