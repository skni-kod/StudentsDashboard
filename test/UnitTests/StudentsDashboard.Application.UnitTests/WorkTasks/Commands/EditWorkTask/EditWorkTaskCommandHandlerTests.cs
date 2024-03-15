using StudentsDashboard.Application.Persistance;
using Moq;
using StudentsDashboard.Application.UnitTests.WorkEvent.TestUtils;
using FluentAssertions;


namespace StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask
{

    public class EditWorkTaskCommandHandlerTests
    {
        private readonly EditWorkTaskCommandHandler _handler;
        private readonly Mock<IWorkTaskRepository> _mockEditWorkTaskCommandHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        EditWorkTaskCommandHandlerTests()
        {
            _mockEditWorkTaskCommandHandler = new Mock<IWorkTaskRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new EditWorkTaskCommandHandler(_mockEditWorkTaskCommandHandler.Object, _mockIUserContextGetIdService.Object);

        }



        [Fact]
        public async Task Handle_Should_ReturnErrorEditWorkTask_WhenIsNotValue()
        {
            // Arrange
            var editWorkTaskCommand = EditWorkTaskCommandUtils.EditWorkTaskCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

            // Act
            var result = await _handler.Handle(editWorkTaskCommand, default);

            // Assert
            result.IsError.Should().BeTrue();
        }


        [Fact]
        public async Task Handle_Should_ReturnEditWorkTask_WhenIsValue()
        {
            // Arrange
            var editWorkTaskCommand = EditWorkTaskCommandUtils.EditWorkTaskCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(value: null);

            // Act
            var result = await _handler.Handle(editWorkTaskCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
        }
    }
}
