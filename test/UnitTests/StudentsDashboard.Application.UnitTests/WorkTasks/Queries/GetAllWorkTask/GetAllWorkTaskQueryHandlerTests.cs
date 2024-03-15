using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkTasks.TestUtils;
using StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask;

namespace StudentsDashboard.Application.WorkTasks.Queries.GetAllWorkTask
{
    public class GetAllWorkTaskQueryHandlerTests
    {
        private readonly GetAllWorkTaskQueryHandler _handler;
        private readonly Mock<IWorkTaskRepository> _mockGetALLWorkTaskQueryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        GetAllWorkTaskQueryHandlerTests()
        {
            _mockGetALLWorkTaskQueryHandler = new Mock<IWorkTaskRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new GetAllWorkTaskQueryHandler(_mockGetALLWorkTaskQueryHandler.Object, _mockIUserContextGetIdService.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorGetAllWorkTask_WhenIsNotValue()
        {
            // Arrange
            var getAllWorkTaskQuery = new GetAllWorkTaskQuery();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

            _mockGetALLWorkTaskQueryHandler.Setup(x => x.GetAllTask(It.IsAny<int>()))
               .ReturnsAsync(value: null);
            // Act
            var result = await _handler.Handle(getAllWorkTaskQuery, default);



            // Assert
            result.IsError.Should().BeTrue();
        }


        [Fact]
        public async Task Handle_Should_ReturnGetAllWorkTask_WhenIsValue()
        {
            // Arrange
            var getAllWorkTaskQuery = new GetAllWorkTaskQuery();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

            // Act
            var result = await _handler.Handle(getAllWorkTaskQuery, default);

            _mockIUserContextGetIdService.Verify(x => x.GetUserId, Times.Once);
            _mockGetALLWorkTaskQueryHandler.Verify(x => x.GetAllTask(It.IsAny<int>()), Times.Once);

            // Assert
            result.IsError.Should().BeFalse();
        }
    }
}
