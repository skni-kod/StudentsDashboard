using FluentAssertions;
using FluentValidation.TestHelper;
using MediatR;
using Moq;
using StudentsDashboard.Application.Authentication.Commands.Register;
using StudentsDashboard.Application.Authentication.Events;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.Authentication.Commands.TestUtils;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.UnitTests.Authentication.Commands.Register;

public class RegisterCommandHandlerTests
{
    private readonly RegisterCommandHandler _handler;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IMediator> _mockMediator;

    public RegisterCommandHandlerTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMediator = new Mock<IMediator>();
        _handler = new RegisterCommandHandler(_mockUserRepository.Object, _mockMediator.Object);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnErrorDuplicateEmail_WhenEmailIsNotUnique()
    {
        // Arrange
        var registerCommand = RegisterCommandUtils.RegisterCommand();

        _mockUserRepository
            .Setup(x => x.Any(It.IsAny<string>()))
            .Returns(true);
        
        // Act
        var result = await _handler.Handle(registerCommand, default);
        
        // Assert
        result.IsError.Should().BeTrue();
    }
    
    [Fact]
    public async Task Handle_Should_ReturnRegisterResponse_WhenEmailIsUnique()
    {
        // Arrange
        var registerCommand = RegisterCommandUtils.RegisterCommand();

        _mockUserRepository
            .Setup(x => x.Any(It.IsAny<string>()))
            .Returns(false);
        _mockUserRepository
            .Setup(x => x.Add(It.IsAny<User>()))
            .Returns(1);
        _mockMediator
            .Setup(x => 
                x.Publish(It.IsAny<UserRegisteredEvent>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        
        // Act
        var result = await _handler.Handle(registerCommand, default);
        
        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
    }
}