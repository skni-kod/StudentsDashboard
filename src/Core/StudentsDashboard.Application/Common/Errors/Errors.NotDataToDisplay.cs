using ErrorOr;

namespace StudentsDashboard.Application.Common.Errors;

public static partial class Errors
{
    public static class NotDataToDisplay
    {
        public static Error notDataToDisplay => Error.Conflict(
            code: "Data error",
            description: "You have not data to dispaly"
        );
    }
}