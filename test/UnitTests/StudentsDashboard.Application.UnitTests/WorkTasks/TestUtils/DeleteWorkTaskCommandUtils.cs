using StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask;
using Constants = StudentsDashboard.Application.UnitTests.TestUtils.Constants.Constants;

namespace StudentsDashboard.Application.UnitTests.WorkTask.TestUtils;

public static class DeleteWorkTaskCommandUtils
{
    public static DeleteWorkTaskCommand DeleteWorkTaskCommand() =>
        new DeleteWorkTaskCommand(
            Constants.WorkTask.Id
            );
}