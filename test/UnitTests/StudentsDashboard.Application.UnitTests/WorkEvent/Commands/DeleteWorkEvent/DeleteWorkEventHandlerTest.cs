using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;
using StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Commands.DeleteWorkEvent;

public class DeleteWorkEventHandlerTest
{
    private readonly DeleteWorkEventHandler _handler;
    private readonly Mock<IWorkEventRepository> _mockIWorkEventRepository;
    private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

    public DeleteWorkEventHandlerTest()
    {
        _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
        _mockIWorkEventRepository = new Mock<IWorkEventRepository>();
        _handler = new DeleteWorkEventHandler(_mockIUserContextGetIdService.Object, _mockIWorkEventRepository.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnErrorUserDoesNotLogged_WhenTokenJwtIsBad()
    {
        //Arrange
        var deleteCommand = DeleteWorkEventCommandUtils.DeleteWorkEventCommand();

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

        //Act
        var result = await _handler.Handle(deleteCommand, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnOwnerError_WhenUserDidntCreateEvent()
    {
        //Arrange
        var deleteHandler = DeleteWorkEventCommandUtils.DeleteWorkEventCommand();

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);
        
        _mockIWorkEventRepository.Setup(x => x.HasPermision(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(false);

        //Act
        var result = await _handler.Handle(deleteHandler, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Hande_Should_ReturnSuccessfull_WhenEventDeleted()
    {
        //Arrange
        var deleteHandler = DeleteWorkEventCommandUtils.DeleteWorkEventCommand();
        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

        _mockIWorkEventRepository.Setup(x => x.HasPermision(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(true);

        //Act
        var result = await _handler.Handle(deleteHandler, default);

        //Assert
        result.IsError.Should().BeFalse();
    }
}