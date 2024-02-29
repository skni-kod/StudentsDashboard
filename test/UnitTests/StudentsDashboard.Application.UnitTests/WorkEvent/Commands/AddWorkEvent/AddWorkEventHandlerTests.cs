using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;
using StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Commands.AddWorkEvent;

public class AddWorkEventHandlerTests
{
    private readonly AddWorkEventHandler _handler;
    private readonly Mock<IWorkEventRepository> _mockInterface;
    private readonly Mock<IUserContextGetIdService> _mockGetUserId;

    public AddWorkEventHandlerTests()
    {
        _mockInterface = new Mock<IWorkEventRepository>();
        _mockGetUserId = new Mock<IUserContextGetIdService>();
        _handler = new AddWorkEventHandler(_mockInterface.Object, _mockGetUserId.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnErrorUserDoesNotLogged_WhenTokenJwtIsBad()
    {
        //Arrange
        var eventHandler = AddWorkEventCommandUtils.AddWorkEventCommand();

        _mockGetUserId.Setup(x => x.GetUserId)
            .Returns((int?)null);

        //Act
        var result = await _handler.Handle(eventHandler, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnUserId_WhenUserLogged()
    {
        //Arrange
        var eventHandler = AddWorkEventCommandUtils.AddWorkEventCommand();

        _mockGetUserId.Setup(x => x.GetUserId)
            .Returns(1);

        //Act
        var result = await _handler.Handle(eventHandler, default);

        //Assert
        result.IsError.Should().BeFalse();
    }
}