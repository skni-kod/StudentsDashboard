namespace StudentsDashboard.Application.Common.Errors;
using ErrorOr;

public static partial class Errors
{
    public static class WorkEvent
    {
        public static Error NotDataToDisplay => Error.Conflict(
            code: "Data error",
            description: "You have not data to dispaly"
        );
        
        public static Error OwnerError => Error.Conflict(
            code: "You are not owner!",
            description: "You can edit only your events!"

        );
        
        public static Error UserDoesNotLogged => Error.Conflict(
            code: "You does not logged!",
            description: "You should loggin before action!"

        );
    }
}