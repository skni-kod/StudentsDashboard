using StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask;
using StudentsDashboard.Application.UnitTests.TestUtils.Constants;

namespace StudentsDashboard.Application.UnitTests.WorkTasks.TestUtils
{
    public static class AddWorkTaskCommandUtils
    {

        public static AddWorkTaskCommand AddWorkTaskCommand() =>
            new AddWorkTaskCommand(
                Constants.WorkTask.Name,
                Constants.WorkTask.Description,
                Constants.WorkTask.Date
                );
            
    }
}
