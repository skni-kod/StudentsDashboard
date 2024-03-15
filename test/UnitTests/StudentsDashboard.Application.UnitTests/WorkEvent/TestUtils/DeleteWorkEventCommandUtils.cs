using StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;
using Constants = StudentsDashboard.Application.UnitTests.TestUtils.Constants.Constants;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;

public static class DeleteWorkEventCommandUtils
{
    public static DeleteWorkEventCommand DeleteWorkEventCommand() =>
        new DeleteWorkEventCommand(
            Constants.Events.Id
            );
}