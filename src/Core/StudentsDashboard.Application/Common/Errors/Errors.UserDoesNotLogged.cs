using ErrorOr;

namespace StudentsDashboard.Application.Common.Errors;

public static partial class Errors
{
    public static class UserDoesNotLogged
    {
        public static Error userDoesNotLogged => Error.Conflict(
            code: "You does not logged!",
            description: "You should loggin before action!"

        );
    }
}