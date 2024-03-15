using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask;
using StudentsDashboard.Application.UnitTests.WorkTasks.TestUtils;
using FluentAssertions;

namespace StudentsDashboard.Application.UnitTests.WorkTasks.Commands.AddWorkTask
{
    public class AddWorkTaskCommandHandlerTests
    {
        private readonly AddWorkTaskCommandHandler _handler;
        private readonly Mock<IWorkTaskRepository> _mockAddWorkTaskCommandHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        AddWorkTaskCommandHandlerTests()
        {
            _mockAddWorkTaskCommandHandler = new Mock<IWorkTaskRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new AddWorkTaskCommandHandler(_mockAddWorkTaskCommandHandler.Object, _mockIUserContextGetIdService.Object);

        }



        [Fact]
        public async Task Handle_Should_ReturnErrorAddWorkTask_WhenIsNotValue()
        {
            // Arrange
            var addWorkTaskCommand = AddWorkTaskCommandUtils.AddWorkTaskCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

            // Act
            var result = await _handler.Handle(addWorkTaskCommand, default);

            // Assert
            result.IsError.Should().BeTrue();
        }


        [Fact]
        public async Task Handle_Should_ReturnAddWorkTask_WhenIsValue()
        {
            // Arrange
            var addWorkTaskCommand = AddWorkTaskCommandUtils.AddWorkTaskCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

            // Act
            var result = await _handler.Handle(addWorkTaskCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
        }
    }
}
