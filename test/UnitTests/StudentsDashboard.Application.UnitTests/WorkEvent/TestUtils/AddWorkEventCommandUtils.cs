using StudentsDashboard.Application.UnitTests.TestUtils.Constants;
using StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;

public static class AddWorkEventCommandUtils
{
    public static AddWorkEventCommand AddWorkEventCommand() =>
        new AddWorkEventCommand(
            Constants.Events.Title,
            Constants.Events.FromDate,
            Constants.Events.FromTime,
            Constants.Events.ToDate,
            Constants.Events.ToTime,
            Constants.Events.Location
            );

}