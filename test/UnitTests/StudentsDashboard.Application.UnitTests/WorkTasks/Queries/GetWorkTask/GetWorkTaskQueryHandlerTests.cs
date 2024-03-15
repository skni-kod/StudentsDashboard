using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkTasks.TestUtils;
using StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask;
using StudentsDashboard.Application.WorkTasks.Queries.GetAllWorkTask;

namespace StudentsDashboard.Application.WorkTasks.Queries.GetWorkTask
{
    public class GetWorkTaskQueryHandlerTests
    {
        private readonly GetWorkTaskQueryHandler _handler;
        private readonly Mock<IWorkTaskRepository> _mockGetWorkTaskQueryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        GetWorkTaskQueryHandlerTests()
        {
            _mockGetWorkTaskQueryHandler = new Mock<IWorkTaskRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new GetWorkTaskQueryHandler(_mockGetWorkTaskQueryHandler.Object, _mockIUserContextGetIdService.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorGetAllWorkTask_WhenIsNotValue()
        {
            // Arrange
            var getWorkTaskQuery = new GetWorkTaskQuery(1);

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

            _mockGetWorkTaskQueryHandler.Setup(x => x.GetAllTask(It.IsAny<int>()))
               .ReturnsAsync(value: null);
            // Act
            var result = await _handler.Handle(getWorkTaskQuery, default);

            // Assert
            result.IsError.Should().BeTrue();
        }


        [Fact]
        public async Task Handle_Should_ReturnGetAllWorkTask_WhenIsValue()
        {
            // Arrange
            var getWorkTaskQuery = new GetWorkTaskQuery(1);

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

            // Act
            var result = await _handler.Handle(getWorkTaskQuery, default);

            _mockIUserContextGetIdService.Verify(x => x.GetUserId, Times.Once);
            _mockGetWorkTaskQueryHandler.Verify(x => x.GetTask(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
