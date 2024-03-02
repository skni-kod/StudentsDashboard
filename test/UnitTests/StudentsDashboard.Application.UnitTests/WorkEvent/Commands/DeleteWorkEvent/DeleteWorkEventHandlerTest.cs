using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;
using StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Commands.DeleteWorkEvent;

public class DeleteWorkEventHandlerTest
{
    private readonly DeleteWorkEventHandler _handler;
    private readonly Mock<IWorkEventRepository> _mockWorkEvent;
    private readonly Mock<IUserContextGetIdService> _mockGetUserId;

    public DeleteWorkEventHandlerTest()
    {
        _mockGetUserId = new Mock<IUserContextGetIdService>();
        _mockWorkEvent = new Mock<IWorkEventRepository>();
        _handler = new DeleteWorkEventHandler(_mockGetUserId.Object, _mockWorkEvent.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnErrorUserDoesNotLogged_WhenTokenJwtIsBad()
    {
        //Arrange
        var deteleCommand = DeleteWorkEventCommandUtils.DeleteWorkEventCommand();

        _mockGetUserId.Setup(x => x.GetUserId)
            .Returns((int?)null);

        //Act
        var result = await _handler.Handle(deteleCommand, default);

        //Assert
        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Equal(Errors.WorkEvent.UserDoesNotLogged, result.Errors.Single());
    }

    [Fact]
    public async Task Handle_Should_ReturnOwnerError_WhenUserDidntCreateEvent()
    {
        //Arrange
        var deleteHandler = DeleteWorkEventCommandUtils.DeleteWorkEventCommand();

        _mockGetUserId.Setup(x => x.GetUserId)
            .Returns(1);
        
        _mockWorkEvent.Setup(x => x.HasPermision(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(false);

        //Act
        var result = await _handler.Handle(deleteHandler, default);

        //Assert
        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Equal(Errors.WorkEvent.OwnerError, result.Errors.Single());
    }

    [Fact]
    public async Task Hande_Should_ReturnSuccessfull_WhenEventDeleted()
    {
        //Arrange
        var deleteHandler = DeleteWorkEventCommandUtils.DeleteWorkEventCommand();
        _mockGetUserId.Setup(x => x.GetUserId)
            .Returns(1);

        _mockWorkEvent.Setup(x => x.HasPermision(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(true);

        //Act
        var result = await _handler.Handle(deleteHandler, default);

        //Assert
        Assert.False(result.IsError);
    }
}