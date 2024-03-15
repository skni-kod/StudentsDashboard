using StudentsDashboard.Application.UnitTests.TestUtils.Constants;
using StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;

public static class EditWorkTaskCommandUtils
{
    public static EditWorkTaskCommand EditWorkTaskCommand() =>
        new EditWorkTaskCommand(
            Constants.WorkTask.Id,
            Constants.WorkTask.Name,
            Constants.WorkTask.Description,
            Constants.WorkTask.Date
            );
}