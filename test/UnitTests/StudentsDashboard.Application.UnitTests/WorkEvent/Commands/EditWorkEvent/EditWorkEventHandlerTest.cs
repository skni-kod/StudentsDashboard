using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;
using StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Commands.EditWorkEvent;

public class EditWorkEventHandlerTest
{
    private readonly EditWorkEventHandler _handlerTest;
    private readonly Mock<IWorkEventRepository> _mockEvent;
    private readonly Mock<IUserContextGetIdService> _mockUserId;

    public EditWorkEventHandlerTest()
    {
        _mockUserId = new Mock<IUserContextGetIdService>();
        _mockEvent = new Mock<IWorkEventRepository>();
        _handlerTest = new EditWorkEventHandler(_mockEvent.Object, _mockUserId.Object);
    }

    [Fact]
    public async Task Handle_Shoud_ReturnNotLoggedError_WhenTokenJwtIsBad()
    {
        //Arrange
        var editCommand = EditWorkEventCommandUtils.EditWorkEventCommand();

        _mockUserId.Setup(x => x.GetUserId)
            .Returns((int?)null);

        //Act
        var result = await _handlerTest.Handle(editCommand, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnOwnerError_WhenDidntCreateEvent()
    {
        //Arrange
        var editCommand = EditWorkEventCommandUtils.EditWorkEventCommand();

        _mockUserId.Setup(x => x.GetUserId)
            .Returns(1);

        _mockEvent.Setup(x => x.HasPermision(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(false);

        //Act
        var result = await _handlerTest.Handle(editCommand, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessfull_WhenUserEdited()
    {
        //Arrange
        var editCommand = EditWorkEventCommandUtils.EditWorkEventCommand();

        _mockUserId.Setup(x => x.GetUserId)
            .Returns(1);

        _mockEvent.Setup(x => x.HasPermision(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(true);

        //Act
        var result = await _handlerTest.Handle(editCommand, default);

        //Assert
        result.IsError.Should().BeFalse(); 
    }
}