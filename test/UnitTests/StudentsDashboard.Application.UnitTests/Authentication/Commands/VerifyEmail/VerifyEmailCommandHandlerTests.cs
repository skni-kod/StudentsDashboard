using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Authentication.Commands.VerifyEmail;
using StudentsDashboard.Application.Common.Errors;
using StudentsDashboard.Application.Persistance;
using StudentsDashboard.Application.UnitTests.Authentication.Commands.TestUtils;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.UnitTests.Authentication.Commands.VerifyEmail;

public class VerifyEmailCommandHandlerTests
{
    private readonly VerifyEmailCommandHandler _handler;
    private readonly Mock<IUserRepository> _mockUserRepository;

    public VerifyEmailCommandHandlerTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _handler = new VerifyEmailCommandHandler(_mockUserRepository.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnErrorUserDoesNotExist_WhenEmailIsInvalid()
    {
        // Arrange

        var verifyEmailCommand = VerifyEmailCommandUtils.VerifyEmailCommand;

        _mockUserRepository
            .Setup(x => x.GetUserByEmail(It.IsAny<string>()))
            .Returns(value: null);
        
        // Act
        
        var result = await _handler.Handle(verifyEmailCommand, default);
        
        // Assert

        result.IsError.Should().BeTrue();
        result.Errors.Should().Contain(Errors.User.UserDoesNotExist);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnErrorVerifiedEmail_WhenEmailIsVerified()
    {
        // Arrange

        var verifyEmailCommand = VerifyEmailCommandUtils.VerifyEmailCommand;

        _mockUserRepository
            .Setup(x => x.GetUserByEmail(It.IsAny<string>()))
            .Returns(new User()
            {
                VerifiedAt = DateTime.UtcNow
            });
        
        // Act
        
        var result = await _handler.Handle(verifyEmailCommand, default);
        
        // Assert

        result.IsError.Should().BeTrue();
        result.Errors.Should().Contain(Errors.User.VerifiedEmail);
    }

    [Fact] 
    public async Task Handle_Should_ReturnErrorInvalidToken_WhenGivenTokenIsNotValid()
    {
        // Arrange

        var verifyEmailCommand = VerifyEmailCommandUtils.VerifyEmailCommand;

        _mockUserRepository
            .Setup(x => x.GetUserByEmail(It.IsAny<string>()))
            .Returns(new User()
            {
                VerificationToken = verifyEmailCommand.Token + "5"
            });
        
        // Act
        
        var result = await _handler.Handle(verifyEmailCommand, default);
        
        // Assert

        result.IsError.Should().BeTrue();
        result.Errors.Should().Contain(Errors.User.InvalidToken);
    }
    
    [Fact] 
    public async Task Handle_Should_ReturnVerifyEmailResponse_WhenEmailHasBeenSuccessfullyVerified()
    {
        // Arrange

        var verifyEmailCommand = VerifyEmailCommandUtils.VerifyEmailCommand;
        
        _mockUserRepository
            .Setup(x => x.GetUserByEmail(It.IsAny<string>()))
            .Returns(new User()
            {
                VerificationToken = verifyEmailCommand.Token
            });
        
        // Act
        
        var result = await _handler.Handle(verifyEmailCommand, default);
        
        // Assert

        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        _mockUserRepository.Verify(x => x.VerifyEmail(It.IsAny<User>()), Times.Once);
    }
    
}