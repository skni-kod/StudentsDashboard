using ErrorOr;

namespace StudentsDashboard.Application.Common.Errors;

public static class Errors
{


    public static class WorkTask
    {
        public static Error NotEnoughData => Error.Conflict(
            code: "not enough information",
            description: "not enough information"

            );
    }
}