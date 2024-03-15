using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkEvents.Queries.GetManyEvents;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Queries.GetEvents;

public class GetEventsHandlerTest
{
    private readonly GetEventsHandler _handler;
    private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;
    private readonly Mock<IWorkEventRepository> _mockIWorkEventRepository;

    public GetEventsHandlerTest()
    {
        _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
        _mockIWorkEventRepository = new Mock<IWorkEventRepository>();
        _handler = new GetEventsHandler(_mockIUserContextGetIdService.Object, _mockIWorkEventRepository.Object);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnErrorUserDoesNotLogged_WhenTokenJwtIsBad()
    {
        // Arrange
        var query = new GetEventsQuery(null);
        _mockIUserContextGetIdService.Setup(x => x.GetUserId).Returns((int?)null);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnNotDataToDisplayError_WhenYouHaveNotAnyDataToDisplay()
    {
        //Arrange
        var query = new GetEventsQuery(null);

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

        _mockIWorkEventRepository.Setup(x => x.GetAllEvents(It.IsAny<int>()))
            .ReturnsAsync(new List<Domain.Entities.WorkEvent>());

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnData_WhenUserLoggedAndWhenDataExists()
    {
        //Arrange
        var mockEvents = new List<Domain.Entities.WorkEvent>
        {
            new Domain.Entities.WorkEvent
            {
                Id = 1,
                Id_Customer = 1,
                Location = 12.34,
                Title = "Test",
                From_Date = DateOnly.Parse("1990-12-12"),
                From_Time = TimeOnly.Parse("12:30"),
                To_Date = DateOnly.Parse("1990-12-12"),
                To_Time = TimeOnly.Parse("12:30")
            }
        };
        
        var query = new GetEventsQuery(null);

        _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

        _mockIWorkEventRepository.Setup(x => x.GetAllEvents(It.IsAny<int>()))
            .ReturnsAsync(mockEvents);

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        _mockIWorkEventRepository.Verify(x => x.GetAllEvents(1), Times.Once);

        result.IsError.Should().BeFalse();
    }
}