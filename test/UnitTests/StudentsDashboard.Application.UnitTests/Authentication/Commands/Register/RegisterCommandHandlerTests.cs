using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Authentication.Commands.Register;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.Authentication.Commands.TestUtils;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.UnitTests.Authentication.Commands.Register;

public class RegisterCommandHandlerTests
{
    private readonly RegisterCommandHandler _handler;
    private readonly Mock<IUserRepository> _mockUserRepository;

    public RegisterCommandHandlerTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _handler = new RegisterCommandHandler(_mockUserRepository.Object);
    }
    
    [Fact]
    public async Task HandleRegisterCommand_ForValidModel_ShouldCreateUser()
    {
        // Arrange
        var registerCommand = RegisterCommandUtils.RegisterCommand();
        
        // Act
        var result = await _handler.Handle(registerCommand, default);
        
        // Assert
        result.IsError.Should().BeFalse();
        _mockUserRepository.Verify(x => x.Add(It.Is<User>(x =>
            x.Email == registerCommand.Email)), Times.Once);
    }
}