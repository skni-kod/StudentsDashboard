using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;
using StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Commands.AddWorkEvent;

public class AddWorkEventHandlerTests
{
    private readonly AddWorkEventHandler _handler;
    private readonly Mock<IWorkEventRepository> _mockIWorkEventRepository;
    private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

    public AddWorkEventHandlerTests()
    {
        _mockIWorkEventRepository = new Mock<IWorkEventRepository>();
        _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
        _handler = new AddWorkEventHandler(_mockIWorkEventRepository.Object, _mockIUserContextGetIdService.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnErrorUserDoesNotLogged_WhenTokenJwtIsBad()
    {
        //Arrange
        var eventHandler = AddWorkEventCommandUtils.AddWorkEventCommand();

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

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

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

        //Act
        var result = await _handler.Handle(eventHandler, default);

        //Assert
        result.IsError.Should().BeFalse();
    }
}