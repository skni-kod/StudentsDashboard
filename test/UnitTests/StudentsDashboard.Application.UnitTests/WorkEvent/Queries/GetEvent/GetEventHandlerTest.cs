using Moq;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkEvent.DataToTests;
using StudentsDashboard.Application.WorkEvents.Queries.GetSpecificEvent;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Queries.GetEvent;

public class GetEventHandlerTest
{
    private readonly GetEventHandler _handler;
    private readonly Mock<IUserContextGetIdService> _mockUserId;
    private readonly Mock<IWorkEventRepository> _mockWorkEvent;

    public GetEventHandlerTest()
    {
        _mockUserId = new Mock<IUserContextGetIdService>();
        _mockWorkEvent = new Mock<IWorkEventRepository>();
        _handler = new GetEventHandler(_mockUserId.Object, _mockWorkEvent.Object);
    }

    [Fact]
    public async Task Hander_Should_ReturnUserNotLoggedError_WhenJwtTokenIsBad()
    {
        //Arrange
        var query = new GetEventQuery(1);

        _mockUserId.Setup(x => x.GetUserId)
            .Returns((int?)null);

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

        _mockUserId.Setup(x => x.GetUserId)
            .Returns(1);

        _mockWorkEvent.Setup(x => x.GetEvent(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync((IEnumerable<Domain.Entities.WorkEvent>)null);

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Equal(Errors.WorkEvent.NotDataToDisplay, result.Errors.Single());
    }

    [Fact]
    public async Task Handle_Should_ReturnData_WhenDataExists()
    {
        //Arrange
        var eventId = 2;
        var query = new GetEventQuery(eventId);
        var userId = 1;
        var dummyData = DataToTestsQueries.DummyDataToSpecificEcent();

        _mockUserId.Setup(x => x.GetUserId)
            .Returns(userId);

        _mockWorkEvent.Setup(x => x.GetEvent(eventId, userId))
            .ReturnsAsync(dummyData);

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        Assert.False(result.IsError);
    }
}