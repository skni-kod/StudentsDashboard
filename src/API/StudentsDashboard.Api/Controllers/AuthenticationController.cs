using System.Security.Cryptography;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Application.Authentication.Commands.Register;
using StudentsDashboard.Application.Authentication.Commands.VerifyEmail;
using StudentsDashboard.Application.Contracts.Authentication;

namespace StudentsDashboard.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.ConfirmPassword);

        var response = await _mediator.Send(command);
        return response.Match(
            registerResponse => Ok(registerResponse),
            errors => Problem(errors));
    }

    [HttpPost("verify-email")]
    public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request)
    {
        var command = new VerifyEmailCommand(
            request.Email,
            request.Token
        );

        var response = await _mediator.Send(command);

        return response.Match(
            verifyEmailResponse => Ok(verifyEmailResponse),
            errors => Problem(errors));
    }
}