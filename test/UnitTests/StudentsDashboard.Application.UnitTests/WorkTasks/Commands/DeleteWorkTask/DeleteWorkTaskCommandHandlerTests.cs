using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.WorkTask.TestUtils;
using StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask;


namespace StudentsDashboard.Application.UnitTests.WorkTasks.Commands.DeleteWorkTask
{
    public class DeleteWorkTaskCommandHandlerTests
    {
        private readonly DeleteWorkTaskCommandHandler _handler;
        private readonly Mock<IWorkTaskRepository> _mockDeleteWorkTaskCommandHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;


        public DeleteWorkTaskCommandHandlerTests()
        {
            _mockDeleteWorkTaskCommandHandler = new Mock<IWorkTaskRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new DeleteWorkTaskCommandHandler(_mockDeleteWorkTaskCommandHandler.Object, _mockIUserContextGetIdService.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteWorkTask_WhenIsNotValue() // Handle_Should_ReturnErrorGetWorkTask_WhenIsNotValue()
        {
            //Arrange
            var deleteWorkTaskCommand = DeleteWorkTaskCommandUtils.DeleteWorkTaskCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //Act
            var result = await _handler.Handle(deleteWorkTaskCommand, default);

            //Assert
            result.IsError.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ReturnDeleteWorkTask_WhenIsValue()
        {
            //Arrange
            var deleteWorkTaskCommand = DeleteWorkTaskCommandUtils.DeleteWorkTaskCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
            .Returns(1);

            //Act
            var result = await _handler.Handle(deleteWorkTaskCommand, default);

            //Assert
            result.IsError.Should().BeFalse();
        }
    }
}
