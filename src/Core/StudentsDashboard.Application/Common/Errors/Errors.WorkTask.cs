using ErrorOr;

namespace StudentsDashboard.Application.Common.Errors;

public static partial class  Errors
{


    public static class WorkTask
    {
        public static Error NotEnoughData => Error.Conflict(
            code: "not enough information",
            description: "not enough information"

            );

        public static Error UserDoesNotLogged => Error.Conflict(
            code: "You does not logged!",
            description: "You should loggin before action!"
            );

        public static Error NotDataToDisplay => Error.Conflict(
            code: "Data error",
            description: "You have not data to dispaly"
    );
    }


}