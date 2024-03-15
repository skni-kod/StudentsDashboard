using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkEvents.Queries.GetSpecificEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Queries.GetEvent;

public class GetEventHandlerTest
{
    private readonly GetEventHandler _handler;
    private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;
    private readonly Mock<IWorkEventRepository> _mockIWorkEventRepository;

    public GetEventHandlerTest()
    {
        _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
        _mockIWorkEventRepository = new Mock<IWorkEventRepository>();
        _handler = new GetEventHandler(_mockIUserContextGetIdService.Object, _mockIWorkEventRepository.Object);
    }

    [Fact]
    public async Task Hander_Should_ReturnUserNotLoggedError_WhenJwtTokenIsBad()
    {
        //Arrange
        var query = new GetEventQuery(1);

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Equal(Errors.WorkEvent.UserDoesNotLogged, result.Errors.Single());
    }

    [Fact]
    public async Task Handle_Should_ReturnNotDataToDisplayError_WhenEventDoesntExist()
    {
        //Arrange
        var query = new GetEventQuery(3);

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

        _mockIWorkEventRepository.Setup(x => x.GetEvent(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(value: null);

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnData_WhenDataExists()
    {
        //Arrange
        var query = new GetEventQuery(1);

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        _mockIUserContextGetIdService.Verify(x => x.GetUserId, Times.Once);
        _mockIWorkEventRepository.Verify(x => x.GetEvent(It.IsAny<int>(),It.IsAny<int>()), Times.Once);

        result.IsError.Should().BeFalse();
    }
}