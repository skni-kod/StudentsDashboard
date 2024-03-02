﻿using Moq;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkEvents.Queries.GetManyEvents;

namespace StudentsDashboard.Application.UnitTests.WorkEvent.Queries.GetEvents;

public class GetEventsHandlerTest
{
    private readonly GetEventsHandler _handler;
    private readonly Mock<IUserContextGetIdService> _mockUserId;
    private readonly Mock<IWorkEventRepository> _mockWorkEvent;

    public GetEventsHandlerTest()
    {
        _mockUserId = new Mock<IUserContextGetIdService>();
        _mockWorkEvent = new Mock<IWorkEventRepository>();
        _handler = new GetEventsHandler(_mockUserId.Object, _mockWorkEvent.Object);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnErrorUserDoesNotLogged_WhenTokenJwtIsBad()
    {
        // Arrange
        var query = new GetEventsQuery(null);
        _mockUserId.Setup(x => x.GetUserId).Returns((int?)null);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Single(result.Errors); 
        Assert.Equal(Errors.WorkEvent.UserDoesNotLogged, result.Errors.Single()); 
    }

    [Fact]
    public async Task Handle_Should_ReturnNotDataToDisplayError_WhenYouHaveNotAnyDataToDisplay()
    {
        //Arrange
        var query = new GetEventsQuery(null);

        _mockUserId.Setup(x => x.GetUserId)
            .Returns(1);

        _mockWorkEvent.Setup(x => x.GetAllEvents(It.IsAny<int>()))
            .ReturnsAsync(new List<Domain.Entities.WorkEvent>());

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Equal(Errors.WorkEvent.NotDataToDisplay, result.Errors.Single());
    }

    [Fact]
    public async Task Handle_Should_ReturnData_WhenUserLoggedAndWhenDataExists()
    {
        //Arrange
        var query = new GetEventsQuery(null);
        var userId = 1;
        var workEvent = new List<Domain.Entities.WorkEvent>
        {
            new Domain.Entities.WorkEvent
            {
                Id = 1, 
                Id_Customer = 1, 
                Location = 12.34, 
                Title = "Test",
                From_Date = DateOnly.Parse("2022-12-12"), 
                From_Time = TimeOnly.Parse("19:00:00"),
                To_Date = DateOnly.Parse("2022-12-13"), 
                To_Time = TimeOnly.Parse("12:00:00")
            }
        };

        _mockUserId.Setup(x => x.GetUserId)
            .Returns(userId);

        _mockWorkEvent.Setup(x => x.GetAllEvents(userId))
            .ReturnsAsync(workEvent);

        //Act
        var result = await _handler.Handle(query, default);

        //Assert
        Assert.False(result.IsError);
    }
}