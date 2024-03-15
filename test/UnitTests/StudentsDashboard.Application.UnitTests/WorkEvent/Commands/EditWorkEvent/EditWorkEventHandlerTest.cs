using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;
using StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Commands.EditWorkEvent;

public class EditWorkEventHandlerTest
{
    private readonly EditWorkEventHandler _handler;
    private readonly Mock<IWorkEventRepository> _mockIWorkEventRepository;
    private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

    public EditWorkEventHandlerTest()
    {
        _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
        _mockIWorkEventRepository = new Mock<IWorkEventRepository>();
        _handler = new EditWorkEventHandler(_mockIWorkEventRepository.Object, _mockIUserContextGetIdService.Object);
    }

    [Fact]
    public async Task Handle_Shoud_ReturnNotLoggedError_WhenTokenJwtIsBad()
    {
        //Arrange
        var editCommand = EditWorkEventCommandUtils.EditWorkEventCommand();

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

        //Act
        var result = await _handler.Handle(editCommand, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnOwnerError_WhenDidntCreateEvent()
    {
        //Arrange
        var editCommand = EditWorkEventCommandUtils.EditWorkEventCommand();

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

        _mockIWorkEventRepository.Setup(x => x.HasPermision(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(false);

        //Act
        var result = await _handler.Handle(editCommand, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessfull_WhenUserEdited()
    {
        //Arrange
        var editCommand = EditWorkEventCommandUtils.EditWorkEventCommand();

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

        _mockIWorkEventRepository.Setup(x => x.HasPermision(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(true);

        //Act
        var result = await _handler.Handle(editCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
    }
}