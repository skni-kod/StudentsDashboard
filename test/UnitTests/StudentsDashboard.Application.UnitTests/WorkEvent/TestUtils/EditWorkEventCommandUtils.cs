using StudentsDashboard.Application.UnitTests.TestUtils.Constants;
using StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;

public static class EditWorkEventCommandUtils
{
    public static EditWorkEventCommand EditWorkEventCommand() =>
        new EditWorkEventCommand(
            Constants.Events.Id,
            Constants.Events.Title,
            Constants.Events.FromDate,
            Constants.Events.FromTime,
            Constants.Events.ToDate,
            Constants.Events.ToTime,
            Constants.Events.Location
            );
}