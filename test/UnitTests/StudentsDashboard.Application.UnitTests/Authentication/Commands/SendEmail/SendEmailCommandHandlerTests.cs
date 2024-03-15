using FluentAssertions;
using Moq;
using StudentsDashboard.Application.Authentication.Commands.SendEmail;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using StudentsDashboard.Application.Common.Models;
using StudentsDashboard.Application.UnitTests.Authentication.Commands.TestUtils;

namespace StudentsDashboard.Application.UnitTests.Authentication.Commands.SendEmail;

public class SendEmailCommandHandlerTests
{
    private readonly SendEmailCommandHandler _handler;
    private readonly Mock<IEmailSender> _mockEmailSender;
    
    public SendEmailCommandHandlerTests()
    {
        _mockEmailSender = new Mock<IEmailSender>();
        _handler = new SendEmailCommandHandler(_mockEmailSender.Object);
    }

    [Fact]
    public async Task Handle_Should_SendEmail_WhenRegistrationSuccessful()
    {
        // Arrange
        
        var sendEmailCommand = SendEmailCommandUtils.SendEmailCommand();
        
        // Act
        
        await _handler.Handle(sendEmailCommand, default);
        
        // Assert
        
        _mockEmailSender.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once);

    }
}