using ErrorOr;

namespace StudentsDashboard.Application.Common.Errors;

public static partial class Errors
{
    public static class OwnerError
    {
        public static Error ownerError => Error.Conflict(
            code: "You are not owner!",
            description: "You can edit only your events!"

        );
    }
}